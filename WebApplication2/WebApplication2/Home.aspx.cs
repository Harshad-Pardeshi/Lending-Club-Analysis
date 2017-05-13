using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            //int ficoValue = Convert.ToInt32(FicoScore.SelectedValue);
            //Decimal LoanAmt = Convert.ToDecimal(txtLoanAmount);
            //Decimal dti = Convert.ToDecimal(txtDti);
            Console.Write("Invoking web services");
            int isClassficcation = Convert.ToInt32(InvokeClassification());
            if (isClassficcation == 0)
            {
                Response.Redirect("RejectedLoan.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "enableData", "enableData();", true);
            }
        }

        protected void calculateIntrestRates(object sender, EventArgs e)
        {

            // Manual clustring
            int manualScore = 0;
            int ficoValue = Convert.ToInt32(txtFico.Text);
            int loanTerm = Convert.ToInt32(lstLoanTerm.SelectedValue);
            int empLength = Convert.ToInt32(txtEmplLen);
            String state = selState.SelectedValue;


            String[] state1 = { "AK", "SD", "FL", "ND", "OH", "UT", "MT", "WY", "NE", "TN", "AL", "MO", "OK", "ID", "AR", "NV", "SC" };
            String[] state2 = { "WA", "MS", "DE", "LA", "MN", "HI", "OR", "NM", "GA", "IA", "VA", "IN", "VT", "KS", "WV", "TX", "MI" };
            String[] state3 = { "CO", "WI", "NC", "NJ", "NH", "KY", "RI", "NY", "MD", "ME", "AZ", "PA", "CA", "IL", "CT", "MA", "PR" };

            if (ficoValue > 300)
                manualScore += 1;
            if (ficoValue > 499)
                manualScore += 1;
            if (ficoValue > 649)
                manualScore += 1;

            if(loanTerm == 36)
            {
                manualScore += 1;
            }else
            {
                if (ficoValue > 449)
                {
                    manualScore += 1;
                }
                if(ficoValue > 649)
                {
                    manualScore += 1;
                }
            }

            if (empLength > 0)
                manualScore += 1;
            if (empLength > 4)
                manualScore += 1;
            if (empLength > 8)
                manualScore += 1;

            if(Array.IndexOf(state1, state) > -1)
            {
                manualScore += 1;
            }
            if (Array.IndexOf(state2, state) > -1)
            {
                manualScore += 1;
            }
            if (Array.IndexOf(state3, state) > -1)
            {
                manualScore += 1;
            }

            if(manualScore < 6)
            {
                //Call Manual cluster algorithm 1 
            }
            else if (manualScore < 10)
            {
                //Call Manual cluster algorithm 2 
            }
            else
            {
                //Call Manual cluster algorithm 3 
            }


            //Call Clustring Algorithm

            //Call Prediction Algorithm for Cluster 1
            //Call Prediction Algorithm for Cluster 2
            //Call Prediction Algorithm for Cluster 3
            //Call Prediction Algorithm for Cluster 4


            // NO clustring


        }

        protected string InvokeClassification()
        {
            Console.Write("Forming Jason Object");
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "loan_amnt", txtLoanAmount.Text
                                            },
                                            {
                                                "FicoScore", txtFico.Text
                                            },
                                            {
                                                "dti", txtDti.Text
                                            },
                                            {
                                                "zip_code", txtZipCode.Text
                                            },
                                            {
                                                "emp_length", txtEmplLen.Text
                                            },
                                            {
                                                "addr_state", selState.SelectedValue
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                Console.Write("Jason object created");
                Console.Write("Connecting to Werb service ======>");
                const string apiKey = "RxJ4L6FERzKf6Rx4bgt63u/qKlrW+kVwADBpXXsHDoEOGoNskPBMV+XaD3QVml6vEVMUscecS8rmkPAdZ6aJ5Q=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/a3a64c5e32874f23a0f55cf0ccea6873/services/36fd60ef7fc64b158d2c241a9bfe43d6/execute?api-version=2.0&format=swagger");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = client.PostAsJsonAsync("", scoreRequest).Result;
                string output= null;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Sending Request");
                    String result = response.Content.ReadAsStringAsync().Result;
                    // JObject responseData = JObject.Parse(result);
                    dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(result);
                    output = jsonData.Results.output1[0]["Scored Labels"];
                    //txtResult.Text = cnic;
                    Console.WriteLine("Result: {0}", result);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseContent);
                }
                return output;
            }
        }



        protected string InvokePrediction(String apiKey, String uri)
        {
            Console.Write("Forming Jason Object");
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "loan_amnt", txtLoanAmount.Text
                                            },
                                            {
                                                "FicoScore", txtFico.Text
                                            },
                                            {
                                                "dti", txtDti.Text
                                            },
                                            {
                                                "zip_code", txtZipCode.Text
                                            },
                                            {
                                                "emp_length", txtEmplLen.Text
                                            },
                                            {
                                                "addr_state", selState.SelectedValue
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                Console.Write("Jason object created");
                Console.Write("Connecting to Werb service ======>");
                 // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri(uri);

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = client.PostAsJsonAsync("", scoreRequest).Result;
                string output = null;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Sending Request");
                    String result = response.Content.ReadAsStringAsync().Result;
                    // JObject responseData = JObject.Parse(result);
                    dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(result);
                    output = jsonData.Results.output1[0]["Scored Labels"];
                    //txtResult.Text = cnic;
                    Console.WriteLine("Result: {0}", result);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseContent);
                }
                return output;
            }
        }
    }
}