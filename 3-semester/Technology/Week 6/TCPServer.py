from socket import *
from threading import *

server_port = 12000
server_socket = socket(AF_INET, SOCK_STREAM)
server_socket.bind(('', server_port))
server_socket.listen(1)

def handle_client(connection_socket, address):
    while True:
        sentence = connection_socket.recv(1024).decode()
        if (sentence == "close connection"):
            break
        capitalized_sentence = sentence.upper()
        connection_socket.send(capitalized_sentence.encode())
    connection_socket.close()

def run_server():
    while True:
        connection_socket, address = server_socket.accept()
        Thread(target=handle_client, args=(connection_socket, address)).start()

print('Server is ready to listen')
run_server()