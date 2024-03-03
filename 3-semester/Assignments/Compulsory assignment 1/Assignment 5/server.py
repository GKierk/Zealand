import json
from socket import *
from random import randint
from threading import Thread

serverPort = 5000
serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', serverPort))
serverSocket.listen(1)
print('Server is ready to listen')

def random_number(connectionSocket, data):
    try:
        number1, number2 = data["numbers"].split()
        number1 = int(number1)
        number2 = int(number2)
        if number1 > number2:
            connectionSocket.send(json.dumps({"response": randint(number2, number1)}).encode())
            return
        connectionSocket.send(json.dumps({"response": randint(number1, number2)}).encode())
        return
    except ValueError:
        connectionSocket.send(json.dumps({"error": "Invalid input"}).encode())
        return

def add(connectionSocket, data):
    try:
        number1, number2 = data["numbers"].split()
        number1 = int(number1)
        number2 = int(number2)
        connectionSocket.send(json.dumps({"response": number1 + number2}).encode())
        return
    except ValueError:
        connectionSocket.send(json.dumps({"error": "Invalid input"}).encode())
        return
    
def subtract(connectionSocket, data):
    try:
        number1, number2 = data["numbers"].split()
        number1 = int(number1)
        number2 = int(number2)
        if number2 > number1:
            connectionSocket.send(json.dumps({"response": number2 - number1}).encode())
            return
        connectionSocket.send(json.dumps({"response": number1 - number2}).encode())
        return
    except ValueError:
        connectionSocket.send(json.dumps({"error": "Invalid input"}).encode())
        return

def protocol_error(connectionSocket):
    connectionSocket.send(json.dumps({"error": "Invalid input"}).encode())
    return

def handle_protocol(connectionSocket):
    operation = connectionSocket.recv(1024).decode()
    operation = json.loads(operation)
    connectionSocket.send(json.dumps({"response": "Input numbers"}).encode())
    data = connectionSocket.recv(1024).decode()
    data = json.loads(data)
    match operation["operation"].lower():
        case "random":
            random_number(connectionSocket, data)
        case "add":
            add(connectionSocket, data)
        case "subtract":
            subtract(connectionSocket, data)
        case _:
            protocol_error(connectionSocket)

def handle_client_request(connectionSocket, addr):
    print(addr[0])
    handle_protocol(connectionSocket)
    connectionSocket.close()

def start_server():
    while True:
        connectionSocket, addr = serverSocket.accept()
        t = Thread(target=handle_client_request, args=(connectionSocket, addr))
        t.start()


def main():
    start_server()

if __name__ == "__main__":
    main()