from socket import *

serverName = "localhost"
serverPort = 5000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

def send_server_request():
    for i in range(0, 2):
        try:
            sentence = input("Input sentence: ")
            clientSocket.send(sentence.encode())
            modifiedSentence = clientSocket.recv(1024)
            print("From server: ", modifiedSentence.decode())
        except:
            print("Server is not available")
            break
    clientSocket.close()

def main():
    send_server_request()

__name__ == "__main__" and main()