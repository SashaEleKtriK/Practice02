import random
import time


def print_matrix(matrix):
    ida = len(list(matrix))
    for a in range(0, ida):
        print(list(list(matrix)[a]))


def additional_matrix(mat_a, mat_b):
    ida = len(list(mat_a))
    idb = len(list(list(mat_a)[0]))
    matrix = []
    for a in range(0, ida):
        matrix_str = []
        for b in range(0, idb):
            new = list(list(mat_a)[a])[b] + list(list(mat_b)[a])[b]
            matrix_str.append(new)
        matrix.append(matrix_str)
    return matrix


def scalar_multiply_matrix(scalar, matrix):
    ida = len(list(matrix))
    idb = len(list(list(matrix)[0]))
    new_matrix = []
    for a in range(0, ida):
        matrix_str = []
        for b in range(0, idb):
            new = list(list(matrix)[a])[b] * scalar
            matrix_str.append(new)
        new_matrix.append(matrix_str)
    return new_matrix


def multiply_matrix(mat_a, mat_b):
    matrix = []
    ida = len(list(mat_a))
    idb = len(list(list(mat_b)[0]))
    ida_b = len(list(mat_b))

    for i in range(0, ida):
        matrix_str = []
        for x in range(0, idb):
            new = 0
            for n in range(0, ida_b):
                new += list(list(mat_a)[i])[n] * list(list(mat_b)[n])[x]
            matrix_str.append(new)
        matrix.append(matrix_str)

    return matrix


def get_matrix(a, b, name):
    matrix = []
    for _ in range(0, a):
        matrix_str = []
        for __ in range(0, b):
            matrix_str.append(random.randint(0, 10000) + random.randint(0, 100) / 100)

        matrix.append(matrix_str)
    # print("Matrix " + str(name))
    # print_matrix(matrix)
    return matrix


def dgemm(a, b, c):
    a_b = multiply_matrix(a, b)
    alfa_a_b = scalar_multiply_matrix(alfa, a_b)
    beta_c = scalar_multiply_matrix(beta, c)
    result = additional_matrix(alfa_a_b, beta_c)
    return result
    # print(result matrix)
    # print_matrix(result)


full_time = 0.0
for i in range(0, 100):
    m = random.randint(1, 100)
    k = random.randint(1, 100)
    n = random.randint(1, 100)
    alfa = random.randint(0, 100)
    beta = random.randint(0, 100)
    a_matrix = get_matrix(m, k, "A")
    b_matrix = get_matrix(k, n, "B")
    c_matrix = get_matrix(m, n, "C")
    start_time = time.time() * 1000
    dgemm(a_matrix, b_matrix, c_matrix)
    result_time = time.time() * 1000
    full_time += result_time - start_time

print(f'Время выполнения, 100 операций {full_time} мс')
#TODO Время выполнения, 100 операций 26271.9912109375 мс
#TODO Время выполнения, 100 операций 21965.48291015625 мс
#TODO Время выполнения, 100 операций 23022.698486328125 мс
#TODO Время выполнения, 100 операций 27338.3994140625 мс