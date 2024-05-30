# Welcome!

This repository contains laboratory works 1-6 for subject "Object-oriented technologies of programming" from Belarusian state university informatics and radioelectronics.

## Installation

Use https://github.com/EvgenSavenok/OOP.git to load repository on your machine.

```bash
git clone https://github.com/EvgenSavenok/OOP.git
```

## Description

### 1. "Ознакомление с концепциями ООП: наследование и полиморфизм типов (виртуальные методы)"

Построить иерархию классов для вывода графических фигур: отрезок, прямоугольник, эллипс и т.д - не менее 6 фигур. Распределить классы по модулям. 
Создать список фигур в виде отдельного класса. 
В главном модуле программы добавить в список различные фигуры (статическая инициализация), после чего запустить рисование списка фигур. 
Выполнить задание на языке C++, C# или Java. 
Для рисования использовать любую подходящую графическую библиотеку. 
Если изучение графической библиотеки вызывает затруднение, допускается вывод фигур в файл или на экран в виде текстовых строк вида "Rectangle(10, 20, 30, 40)".
Задание выполняется с использованием системы контроля версий git.

Плюсом будет использование своей иерархии.

### 2. "Использование паттернов Стратегия и Фабрика"

Расширить пример с графическими фигурами так, чтобы фигуры можно было создавать на уровне пользовательского интерфейса. 
Существуют несколько способов: ввод координат с помощью мыши, диалоговый ввод значений. Можно выбрать любой способ ввода.
Создание объекта должно выполняться так, чтобы добавление нового класса в систему не требовало изменения существующего кода (выбор типа с помощью оператора case/switch и множественного if делать нельзя). Получившаяся программа должна представлять собой примитивный графический редактор.
Классы фигур не должны содержать метод рисования.

### 3. "Сериализация объектов"

Иерархия из 6 и более классов. Реализовать сериализацию/десереализацию объектов из полученной иерархии классов в файл/из файла, формат сериализации определяется индивидуальным вариантом. 
В пользовательском интерфейсе необходимо реализовать следующие функции:
1) возможность изменять свойства объектов (редактирование);
2) добавлять/удалять объекты из списка;
3) сериализация/десериализация списка объектов.
Добавление новых классов в иерархию не должно приводить к необходимости переписать существующий код, и не использовать if-else/switch-case.

### 4. "Плагины - иерархия"

На основе 2 или 3 лабораторной работы расширить имеющуюся иерархию новыми классами с помощью динамической загрузки модуля (плагина). Новые модули должны добавлять или расширять функциональность базовой программы: новый класс в иерархии, функции по работе с ним, новые элементы в пользовательскм интерфейсе для работы с новым классом.
Загружать модули можно из папки либо посредством строки-параметра в главном модуле с именем нового модуля и возможной перекомпиляцией. 
В идеале добавление нового модуля должно выполняться его динамической загрузкой, т.е. вообще не должно требовать изменения кода программы.

### 5. "Плагины - функциональность".

На базе предыдущей лабораторной работы (№4) на основе плагинов реализовать возможность обработки структур перед сохранением в файл и после загрузки из файла. 
Тип обработки задается вариантом. Дополнительная функциональность должна находиться в меню настроек и зависит от загруженных плагинов. 
Загрузка плагинов производится автоматически из папки, либо выбором файла с плагином через пользовательский интерфейс.

### 6. "Паттерны".

На базе предыдущей лабораторной работы (№5) обменяться с товарищем функциональными плагинами (минимум одним) и адаптировать их в этой же работе помощью паттерна Адаптер (т.е. появятся новые функции от плагина товарища, загруженные через плагин с адаптером).
