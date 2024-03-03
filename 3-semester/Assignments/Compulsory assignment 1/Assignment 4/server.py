from socket import *
from random import randint
from threading import Thread

serverPort = 5000
serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', serverPort))
serverSocket.listen(1)
print('Server is ready to listen')

def random_number(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    try:
        number1, number2 = numbers.split(" ")
        number1 = int(number1)
        number2 = int(number2)
        if number1 > number2:
            connectionSocket.send(str(randint(number2, number1)).encode())
            return
        else:
            connectionSocket.send(str(randint(number1, number2)).encode())
    except ValueError:
        connectionSocket.send("Invalid input, please enter two numbers separated by a space".encode())
        return

def add_numbers(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split(" ")
    number1 = int(number1)
    number2 = int(number2)
    try:
        connectionSocket.send(str(number1 + number2).encode())
        return
    except ValueError:
        connectionSocket.send("Invalid input, please enter two numbers separated by a space".encode())
        return

def subtract_numbers(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split(" ")
    number1 = int(number1)
    number2 = int(number2)
    try:
        if number1 > number2:
            connectionSocket.send(str(number1 - number2).encode())
            return
        else:
            connectionSocket.send(str(number2 - number1).encode())
            return
    except ValueError:
        connectionSocket.send("Invalid input, please enter two numbers separated by a space".encode())
        return

def handle_protocol(connectionSocket, addr):
    sentence = connectionSocket.recv(1024).decode()
    sentence = sentence.lower()
    match sentence:
        case "random":
            random_number(connectionSocket)
            return
        case "add":
            add_numbers(connectionSocket)
            return
        case "subtract":
            subtract_numbers(connectionSocket)
            return
        case _:
            connectionSocket.send("Invalid command".encode())
            return

def handle_client_request(connectionSocket, addr):
    print(addr[0])
    handle_protocol(connectionSocket, addr)
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