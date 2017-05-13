using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
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
            String uri = null;
            String apiKey = null;
            // Manual clustring
            int manualScore = 0;
            int ficoValue = Convert.ToInt32(txtFico.Text);
            int loanTerm = Convert.ToInt32(lstLoanTerm.SelectedValue);
            int empLength = Convert.ToInt32(txtEmplLen.Text);
            String state = lstState.SelectedValue;


            String[] state1 = { "AK", "SD", "FL", "ND", "OH", "UT", "MT", "WY", "NE", "TN", "AL", "MO", "OK", "ID", "AR", "NV", "SC" };
            String[] state2 = { "WA", "MS", "DE", "LA", "MN", "HI", "OR", "NM", "GA", "IA", "VA", "IN", "VT", "KS", "WV", "TX", "MI" };
            String[] state3 = { "CO", "WI", "NC", "NJ", "NH", "KY", "RI", "NY", "MD", "ME", "AZ", "PA", "CA", "IL", "CT", "MA", "PR" };

            if (ficoValue > 300)
                manualScore += 1;
            if (ficoValue > 499)
                manualScore += 1;
            if (ficoValue > 649)
                manualScore += 1;

            if (loanTerm == 36)
            {
                manualScore += 1;
            }
            else
            {
                if (ficoValue > 449)
                {
                    manualScore += 1;
                }
                if (ficoValue > 649)
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

            if (Array.IndexOf(state1, state) > -1)
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

            if (manualScore < 6) //Call Manual cluster algorithm 1 
            {
                apiKey = "f3pYo/cszpREd69JaE7PMc0Ps8juv2L8svAdKtFVyGz8nYUgV/I6mAVivbo2jNkmFaWPeEHd0yOGM2bEi3B0QQ==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/b9cbc79c7e954c4c974566aeab3160bd/services/64bb011ba42a428db9f9ebf3870d37f8/execute?api-version=2.0&format=swagger";
                txtManualOutput.Text = InvokeManualClusterPrediction(apiKey, uri);
            }
            else if (manualScore < 10) //Call Manual cluster algorithm 2
            {
                apiKey = "Nssn6GgDT9+zsBn8P4eGbmw7RHTPP2piE8QAodMj2BReHaEkODWMZvpkT+SGHdX81w6c5ArBW1C2Iokkg5dRJg==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/b9cbc79c7e954c4c974566aeab3160bd/services/e68854e5c1fe4da0840cb43c6438ddea/execute?api-version=2.0&format=swagger";
                txtManualOutput.Text = InvokeManualClusterPrediction(apiKey, uri);
            }
            else  //Call Manual cluster algorithm 3 
            {
                apiKey = "Fnv4//qtOuSNo1n3vhte0ScKFocZk8UYXWPgEXXIznB+IaamWo0zeff0Gmr4XcnMR1OrGuvHmhXcyC6/RiMz0w==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/b9cbc79c7e954c4c974566aeab3160bd/services/4f1d5e780e0d4472bc54de27c44be143/execute?api-version=2.0&format=swagger";
                txtManualOutput.Text = InvokeManualClusterPrediction(apiKey, uri);
            }


            //Call Clustring Algorithm
            apiKey = "01E/cXCN1dXlMfQIMn7DZ+cEd8ltUhOPTuHpWd82/lQPrDn6/X1mnkbI4VRCmbj6K8xJutD+02DX+kafcnS8HQ==";
            uri = "https://ussouthcentral.services.azureml.net/workspaces/a3a64c5e32874f23a0f55cf0ccea6873/services/724172d1b00044e292be57e27a5494f6/execute?api-version=2.0&format=swagger";
            int cluster = Convert.ToInt32(InvokeClustring(apiKey,uri));

            if(cluster == 0)
            {
                //Call Prediction Algorithm for Cluster 1
                apiKey = "zrMnFpsVGBGet2+kcMx7iATop+ItpwzAt5Cd8aAJMXuHipnEU015NeB3+WfvCPBldvf70VY4uyq+HsIh6dJZ6A==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/9f47cbd4806548748c943eea94eda960/services/a20590273d434e79881af4de1816c501/execute?api-version=2.0&format=swagger";
                txtAlgoClustring.Text = InvokeAlgoClusterPrediction(apiKey, uri);
            }else if(cluster == 1)
            {
                //Call Prediction Algorithm for Cluster 2
                apiKey = "0gkcfNkhUKqCmOLPuRI+wBQ2lZid63r0OTbZUEe//Q2JEkZfJdFAxytic3NjL944KkhWVN6bQHWgDGHFk89gYw==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/9f47cbd4806548748c943eea94eda960/services/a066efcdc39948d9b59a82c2c8ccd1d1/execute?api-version=2.0&format=swagger";
                txtAlgoClustring.Text = InvokeAlgoClusterPrediction(apiKey, uri);
            }else if (cluster == 2)
            {
                //Call Prediction Algorithm for Cluster 3
                apiKey = "JMhJxv+KwpCF7Q2lxr0CDjTeg1nvX0FWER2bBW1/0EdzYS7qhPgMlrmmHkg2nsYHh67Hv3Ggwwg0Pq0YtkqaZw==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/9f47cbd4806548748c943eea94eda960/services/9a4fd638405843d8a9d736df691dc8db/execute?api-version=2.0&format=swagger";
                txtAlgoClustring.Text = InvokeAlgoClusterPrediction(apiKey, uri);
            } else if(cluster == 3)
            {
                //Call Prediction Algorithm for Cluster 4
                apiKey = "R/IYRc2K4U5IULBOd2iBFHExu++ZU4lVwzBVV55ANQmrTHGD+hyGxDM/qvdFDHjdiCyCNAd/83+7SwGc1aTgYQ==";
                uri = "https://ussouthcentral.services.azureml.net/workspaces/9f47cbd4806548748c943eea94eda960/services/aa33100df7834a57b226df5b0c9cea21/execute?api-version=2.0&format=swagger";
                txtAlgoClustring.Text = InvokeAlgoClusterPrediction(apiKey, uri);
            }



            // NO clustring
            apiKey = "Zqga5+EiAW4V9bWprc0OL50xXN7GUwtWx8wC1Ll05dWe7Qx2v4sTqdDOKiI0chD9e+Pkb9M24yPECcXXS6I8Pg==";
            uri = "https://ussouthcentral.services.azureml.net/workspaces/a3a64c5e32874f23a0f55cf0ccea6873/services/41a8c53ab3b747ea81179f6bfc908a6b/execute?api-version=2.0&format=swagger";
            txtNoClustring.Text = InvokeNoClusterPrediction(apiKey, uri);
            ScriptManager.RegisterStartupScript(this, GetType(), "enableData", "enableData();", true);
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
                                                "addr_state", lstState.SelectedValue
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


        protected string InvokeNoClusterPrediction(String apiKey, String uri)
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
                                                "sub_grade", txtSubGrade.Text
                                            },
                                            {
                                                "annual_inc", txtAnnualIncome.Text
                                            },
                                            {
                                                "issue_year", txtIssueYear.Text
                                            },
                                            {
                                                "application_type", lstApplicationType.SelectedValue
                                            },
                                            {
                                                "Derived_term", lstLoanTerm.SelectedValue
                                            },
                                            {
                                                "FICO", txtFico.Text
                                            },
                                            {
                                                "derived_emp_length", txtEmplLen.Text
                                            },
                                            {
                                                "addr_state", lstState.SelectedValue
                                            },
                                            {
                                                "loan_amnt", txtLoanAmount.Text
                                            },
                                            {
                                                "verification_status", lstVerificationStatus.SelectedValue
                                            },
                                            {
                                                "home_ownership", lstHomeOwnership.SelectedValue
                                            },
                                            {
                                                "derived_mths_since_last_delinq", txtMthsSinceLastDelinq.Text
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
                    output = jsonData.Results.output1[0]["Scored Label Mean"];
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

        protected string InvokeClustring(String apiKey, String uri)
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
                                                "sub_grade", txtSubGrade.Text
                                            },
                                            {
                                                "derived_int_rate", "10"
                                            },
                                            {
                                                "derived_annual_inc", txtAnnualIncome.Text
                                            },
                                            {
                                                "issue_year", txtIssueYear.Text
                                            },
                                            {
                                                "application_type", lstApplicationType.SelectedValue
                                            },
                                            {
                                                "Derived_term", lstLoanTerm.SelectedValue
                                            },
                                            {
                                                "FICO", txtFico.Text
                                            },
                                            {
                                                "derived_emp_length", txtEmplLen.Text
                                            },
                                            {
                                                "addr_state", lstState.SelectedValue
                                            },
                                            {
                                                "loan_amnt", txtLoanAmount.Text
                                            },
                                            {
                                                "verification_status", lstVerificationStatus.SelectedValue
                                            },
                                            {
                                                "home_ownership", lstHomeOwnership.SelectedValue
                                            },
                                            {
                                                "derived_mths_since_last_delinq", txtMthsSinceLastDelinq.Text
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
                    output = jsonData.Results.output1[0]["Assignments"];
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


        protected string InvokeAlgoClusterPrediction(String apiKey, String uri)
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
                                                "sub_grade", txtSubGrade.Text
                                            },
                                            {
                                                "derived_annual_inc", txtAnnualIncome.Text
                                            },
                                            {
                                                "issue_year", txtIssueYear.Text
                                            },
                                            {
                                                "application_type", lstApplicationType.SelectedValue
                                            },
                                            {
                                                "Derived_term", lstLoanTerm.SelectedValue
                                            },
                                            {
                                                "FICO", txtFico.Text
                                            },
                                            {
                                                "derived_emp_length", txtEmplLen.Text
                                            },
                                            {
                                                "addr_state", lstState.SelectedValue
                                            },
                                            {
                                                "loan_amnt", txtLoanAmount.Text
                                            },
                                            {
                                                "verification_status", lstVerificationStatus.Text
                                            },
                                            {
                                                "home_ownership", lstHomeOwnership.SelectedValue
                                            },
                                            {
                                                "derived_mths_since_last_delinq", txtMthsSinceLastDelinq.Text
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
                    output = jsonData.Results.output1[0]["Scored Label Mean"];
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


        protected string InvokeManualClusterPrediction(String apiKey, String uri)
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
                                                "sub_grade", txtSubGrade.Text
                                            },
                                            {
                                                "annual_inc", txtAnnualIncome.Text
                                            },
                                            {
                                                "issue_year", txtIssueYear.Text
                                            },
                                            {
                                                "application_type", lstApplicationType.SelectedValue
                                            },
                                            {
                                                "Derived_term", lstLoanTerm.SelectedValue
                                            },
                                            {
                                                "FICO", txtFico.Text
                                            },
                                            {
                                                "derived_emp_length", txtEmplLen.Text
                                            },
                                            {
                                                "addr_state", lstState.SelectedValue
                                            },
                                            {
                                                "loan_amnt", txtLoanAmount.Text
                                            },
                                            {
                                                "verification_status", lstVerificationStatus.SelectedValue
                                            },
                                            {
                                                "home_ownership", lstHomeOwnership.SelectedValue
                                            },
                                            {
                                                "derived_mths_since_last_delinq", txtMthsSinceLastDelinq.Text
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