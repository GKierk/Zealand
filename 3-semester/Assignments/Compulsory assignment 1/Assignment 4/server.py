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
    try:
      number1, number2 = numbers.split(" ")
      if number1 > number2:
          return randint(number2, number1)
      else:
        return randint(number1, number2)
    except ValueError:
        return "Invalid input, please enter two numbers separated by a space"

def add_numbers(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split(" ")
    number1 = int(number1)
    number2 = int(number2)
    try:
      return str (number1 + number2)
    except ValueError:
        return "Invalid input, please enter two numbers separated by a space"

def subtract_numbers(connectionSocket):
    message = "Enter two numbers separated by a space: "
    connectionSocket.send(message.encode())
    numbers = connectionSocket.recv(1024).decode()
    number1, number2 = numbers.split(" ")
    try:
      if number1 > number2:
          return number1 - number2
      else:
        return number2 - number1
    except ValueError:
        return "Invalid input, please enter two numbers separated by a space"

def handle_protocol(connectionSocket, addr):
    sentence = connectionSocket.recv(1024).decode()
    sentence = sentence.lower()
    match sentence:
        case "random":
            return random_number(connectionSocket)
        case "add":
            return add_numbers(connectionSocket)
        case "subtract":
            return subtract_numbers(connectionSocket)
        case _:
            return connectionSocket.send("Invalid command".encode())

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