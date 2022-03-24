pipeline {
    agent any

    stages {
       
         stage('Execute Test cases') {
            steps {
                powershell 'dotnet test'
            }
            
            post {
        always {
            nunit testResultsPattern: "**/TestExecution.json"
            }
        }
        }
        
       
    }
}
