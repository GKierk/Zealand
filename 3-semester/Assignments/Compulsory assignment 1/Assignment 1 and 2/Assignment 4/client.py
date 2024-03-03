from socket import *

serverName = "localhost"
serverPort = 12000

def send_server_request():
    while True:
        try:
            clientSocket = socket(AF_INET, SOCK_STREAM)
            clientSocket.connect((serverName, serverPort))
            sentence = input('Input sentence: ')
            clientSocket.send(sentence.encode())
            modifiedSentence = clientSocket.recv(1024)
            print('From server: ', modifiedSentence.decode())
            clientSocket.close()
        except:
            print("Server is not available")
            break

def main():
    send_server_request()

__name__ == "__main__" and main()