from socket import *
from random import randint
from threading import Thread

serverPort = 12000
serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', serverPort))
serverSocket.listen(1)
print('Server is ready to listen')

def random_number(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split()
    if number1 > number2:
        return randint(number2, number1)
    else:
      return randint(number1, number2)

def add_numbers(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split()
    return number1 + number2

def subtract_numbers(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split()
    if number1 > number2:
        return number1 - number2
    else:
      return number2 - number1

def handle_protocol(connectionSocket, addr):
    sentence = connectionSocket.recv(1024).decode()
    sentence = sentence.lower()
    match sentence:
        case "random":
            random_number(connectionSocket)
        case "add":
            add_numbers(connectionSocket)
        case "subtract":
            subtract_numbers(connectionSocket)
        case _:
            connectionSocket.send("Invalid command".encode())

def handle_client(connectionSocket, addr):
    print(addr[0])
    handle_protocol(connectionSocket, addr)
    connectionSocket.close()

def handle_server():
    while True:
        connectionSocket, addr = serverSocket.accept()
        t = Thread(target=handle_client, args=(connectionSocket, addr))
        t.start()


def main():
    handle_server()

if __name__ == "__main__":
    main()