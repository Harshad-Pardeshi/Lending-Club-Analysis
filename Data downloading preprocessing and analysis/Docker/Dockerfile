FROM python:3

USER root

ADD Accepted_Loan_Luigi.py Rejected_Loan_Luigi.py

RUN apt-get update && \
    apt-get clean && \
        rm -rf /var/lib/apt/lists/*

	USER $NB_USER
    
    # Install Python 3 packages
	# Remove pyqt and qt pulled in for matplotlib since we're only ever going to
	# use notebook-friendly backends in these images
	RUN pip install boto
	RUN pip install luigi
	RUN pip install urllib3
	RUN	pip install bs4
	RUN pip install requests
	RUN pip install numpy
	RUN pip install pandas
	RUN	pip install lxml
	RUN	pip install datetime
	RUN	pip install seaborn 
	
	#RUN	pip install sklearn
	#RUN	pip install scipy
	#RUN	pip install https://github.com/pybrain/pybrain/archive/0.3.3.zip

#RUN pip install pystrich

CMD [ "python", "./Accepted_Loan_Luigis.py", "UploadToS3", "--local-scheduler", "--awsKey", "AWS key", "--awsSecret","Secret Key" ]