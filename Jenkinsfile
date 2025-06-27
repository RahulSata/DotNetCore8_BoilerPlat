pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = 1
        BUILD_DIR = 'build_output'
    }

    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'RahulSata', url: 'https://github.com/RahulSata/DotNetCore8_BoilerPlat.git', branch: 'main'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish --configuration Release -o $BUILD_DIR'
            }
        }

        stage('Archive') {
            steps {
                archiveArtifacts artifacts: "$BUILD_DIR/**", fingerprint: true
            }
        }
    }

    post {
        always {
            cleanWs()
        }
    }
}
