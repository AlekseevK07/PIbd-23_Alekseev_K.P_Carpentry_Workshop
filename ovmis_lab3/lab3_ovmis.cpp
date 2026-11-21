#include <iostream>
#include <string>
#include <algorithm>
#include <stdexcept>
#include <limits>

using namespace std;

// Функция для безопасного ввода системы счисления
int askBase(const string& title) {
    int base;
    while (true) {
        cout << title;
        if (cin >> base && base >= 2 && base <= 16) {
            return base;
        }
        cout << "[!] Ошибка: введите целое число от 2 до 16.\n";
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
}

// Ручной перевод из любой системы в десятичную
long long convertToDec(const string& numStr, int base) {
    if (numStr.empty()) throw invalid_argument("Строка не может быть пустой.");

    bool isNegative = false;
    long long result = 0;
    int startIdx = 0;
    string allowedChars = "0123456789ABCDEF";

    if (numStr[0] == '-') {
        isNegative = true;
        startIdx = 1;
    }

    if (startIdx >= numStr.length()) throw invalid_argument("Введен только знак минуса.");

    for (int i = startIdx; i < numStr.length(); ++i) {
        char c = toupper(numStr[i]);
        size_t val = allowedChars.find(c);

        if (val == string::npos || val >= (size_t)base) {
            throw invalid_argument("Символ '" + string(1, c) + "' недопустим для " + to_string(base) + "-й системы.");
        }

        if (result > (LLONG_MAX - val) / base) {
            throw overflow_error("Число слишком велико для обработки.");
        }

        result = result * base + val;
    }

    return isNegative ? -result : result;
}

// Ручной перевод из десятичной в целевую систему
string convertFromDec(long long num, int base) {
    if (num == 0) return "0";

    bool isNegative = num < 0;
    unsigned long long absNum = isNegative ? -num : num;
    string result = "";
    string digits = "0123456789ABCDEF";

    while (absNum > 0) {
        result += digits[absNum % base];
        absNum /= base;
    }

    reverse(result.begin(), result.end());
    return isNegative ? "-" + result : result;
}

// Формирование прямого кода (ПК)
string getDirectCode(long long num) {
    bool isNegative = num < 0;
    // Берем модуль числа (если число отрицательное, меняем знак)
    unsigned long long absNum = isNegative ? -num : num;

    string binStr = "";
    if (absNum == 0) {
        binStr = "0";
    }
    else {
        while (absNum > 0) {
            binStr += to_string(absNum % 2);
            absNum /= 2;
        }
        reverse(binStr.begin(), binStr.end());
    }

    // Определение разрядности (8, 16, 32)
    int totalBits = 8;
    if (binStr.length() + 1 > 8) totalBits = 16;
    if (binStr.length() + 1 > 16) totalBits = 32;
    if (binStr.length() + 1 > 32) throw overflow_error("Число не влезает в 32-битный ПК.");

    // Формирование ПК: ставим знак (1 или 0), добавляем нули и модуль
    string signBit = isNegative ? "1" : "0";
    string directCode = signBit + string(totalBits - 1 - binStr.length(), '0') + binStr;

    // Разбиваем по 4 бита (тетрадам) для красивого вывода
    string formatted = "";
    for (int i = 0; i < totalBits; i += 4) {
        formatted += directCode.substr(i, 4) + " ";
    }

    return "ПК " + formatted.substr(0, formatted.length() - 1);
}

int main() {
    setlocale(LC_ALL, "Russian");
    cout << "=== Лабораторная работа: Системы счисления ===\n";
    cout << "(Для выхода закройте окно программы)\n\n";

    // Бесконечный цикл
    while (true) {
        cout << "\n-------------------------------------------\n";
        try {
            int fromBase = askBase("Введите исходную систему счисления (2-16): ");
            int toBase = askBase("Введите конечную систему счисления (2-16): ");

            string inputNum;
            cout << "Введите число в " << fromBase << "-й системе: ";
            cin >> inputNum;

            long long decValue = convertToDec(inputNum, fromBase);
            string finalResult = convertFromDec(decValue, toBase);

            cout << "\n--- РЕЗУЛЬТАТ ---\n";
            cout << "В " << toBase << "-й системе: " << finalResult << "\n";

            if (toBase == 2) {
                cout << "Прямой код: " << getDirectCode(decValue) << "\n";
            }

        }
        catch (const exception& e) {
            cout << "\n[ОШИБКА] " << e.what() << "\n";
        }

        // Очищаем буфер ввода после каждого цикла, чтобы избежать зацикливания
        // при вводе некорректных символов (например, букв вместо цифр)
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }

    return 0;
}