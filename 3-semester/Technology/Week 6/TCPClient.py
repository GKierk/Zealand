from socket import *

status = 1
server_name = "localhost"
server_port = 12000
client_socket = socket(AF_INET, SOCK_STREAM)
client_socket.connect((server_name, server_port))

def handle_server(client_socket):
  sentence = input('Input sentence: ')
  if (sentence == "close connection"):
    client_socket.close()
    return 0
  else:
    client_socket.send(sentence.encode())
    modifiedSentence = client_socket.recv(1024)
    print('From server: ', modifiedSentence.decode())

def start_client():
  while True:
    status = handle_server(client_socket)
    if (status == 0):
      break

start_client()
client_socket.close()