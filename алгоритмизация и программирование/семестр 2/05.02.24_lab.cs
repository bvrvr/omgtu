using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _05._02._23_lab
{
    internal class Program
    {
        class Auditories
        {
            public int Places, Floor, Auditory;
            public string Projector, Computers;

            public Auditories(int places, string projector, string computers, int floor, int auditory)
            {
                Places = places;
                Projector = projector;
                Computers = computers;
                Floor = floor;
                Auditory = auditory;
            }
        }

        class Menu
        {
            private Auditories[] audArray;
            private int currentIndex = 0;

            public Auditories[] Fill()
            {
                Console.WriteLine("Введите количество аудиторий во всём институте:");
                int m;
                while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество аудиторий во всём институте:");
                }

                Console.Clear();
                Console.WriteLine("Введите количество аудиторий, информацию о которых Вы хотите внести:");
                int n;

                do
                {
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество аудиторий, информацию о которых Вы хотите внести:");
                    }

                    if (n > m)
                    {
                        Console.Clear();
                        Console.WriteLine("Количество аудиторий для ввода не может быть больше общего количества аудиторий в институте. Пожалуйста, введите корректное значение:");
                    }
                } while (n > m);

                this.audArray = new Auditories[m];

                for (int i = 0; i < n; i++)
                {
                    Console.Clear();
                    Console.WriteLine("Введите количество посадочных мест:");
                    int places;
                    while (!int.TryParse(Console.ReadLine(), out places) || places <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                    };

                    string projector;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Наличие прожектора (да/нет):");
                        projector = Console.ReadLine().ToLower();
                    } while (projector != "да" && projector != "нет");

                    string computers;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Наличие компьютеров (да/нет):");
                        computers = Console.ReadLine().ToLower();
                    } while (computers != "да" && computers != "нет");

                    Console.Clear();
                    Console.WriteLine("На каком этаже расположена аудитория?");
                    int floor;
                    while (!int.TryParse(Console.ReadLine(), out floor) || floor <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nНа каком этаже расположена аудитория?");
                    };

                    Console.Clear();
                    Console.WriteLine("Номер аудитории:");
                    int auditory;
                    while (!int.TryParse(Console.ReadLine(), out auditory) || auditory <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nНомер аудитории:");
                    };

                    this.audArray[i] = new Auditories(places, projector, computers, floor, auditory);
                }

                currentIndex = n;
                Console.Clear();
                Console.WriteLine("Данные внесены.");
                Console.WriteLine();
                return this.audArray;
            }

            public void Add()
            {
                if (currentIndex < this.audArray.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Добавление новой аудитории:");
                    Console.WriteLine("Введите количество посадочных мест:");
                    int places;
                    while (!int.TryParse(Console.ReadLine(), out places) || places <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                    };

                    string projector;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Наличие прожектора (да/нет):");
                        projector = Console.ReadLine().ToLower();
                    } while (projector != "да" && projector != "нет");

                    string computers;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Наличие компьютеров (да/нет):");
                        computers = Console.ReadLine().ToLower();
                    } while (computers != "да" && computers != "нет");

                    Console.Clear();
                    Console.WriteLine("На каком этаже расположена аудитория?");
                    int floor;
                    while (!int.TryParse(Console.ReadLine(), out floor) || floor <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nНа каком этаже расположена аудитория?");
                    };

                    Console.Clear();
                    Console.WriteLine("Номер аудитории:");
                    int auditory;
                    while (!int.TryParse(Console.ReadLine(), out auditory) || auditory <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Пожалуйста, введите корректную информацию.\nНомер аудитории:");
                    };

                    this.audArray[currentIndex] = new Auditories(places, projector, computers, floor, auditory);
                    currentIndex++;
                    Console.Clear();
                    Console.WriteLine("Новая аудитория добавлена.");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("В институте больше нет аудиторий. Невозможно добавить новую.");
                    Console.WriteLine();
                }
            }

            public void Change()
            {
                Console.Clear();
                Console.WriteLine("Введите этаж, на котором находится аудитория, информацию о которой Вы хотите изменить:");
                int flr = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите номер аудитории, информацию о которой Вы хотите изменить:");
                int audit = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < currentIndex; i++)
                {
                    if (audArray[i].Floor == flr && audArray[i].Auditory == audit)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите новую информацию.");
                        Console.WriteLine("Введите количество посадочных мест:");
                        int places;
                        while (!int.TryParse(Console.ReadLine(), out places) || places <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                        };

                        string projector;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Наличие прожектора (да/нет):");
                            projector = Console.ReadLine().ToLower();
                        } while (projector != "да" && projector != "нет");

                        string computers;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Наличие компьютеров (да/нет):");
                            computers = Console.ReadLine().ToLower();
                        } while (computers != "да" && computers != "нет");

                        audArray[i].Places = places;
                        audArray[i].Projector = projector;
                        audArray[i].Computers = computers;

                        Console.Clear();
                        Console.WriteLine("Информация об аудитории обновлена.");
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Такой аудитории не существует.");
                        Console.WriteLine();
                    }
                }
            }

            public void AudList1()
            {
                Console.Clear();
                Console.WriteLine("Введите количество посадочных мест:");
                int pl;
                while (!int.TryParse(Console.ReadLine(), out pl) || pl <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                };

                for (int i = 0; i < currentIndex; i++)
                {
                    if (audArray[i].Places >= pl)
                    {
                        Console.Clear();
                        Console.WriteLine($"Аудитория номер {audArray[i].Auditory}, этаж {audArray[i].Floor}");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Таких аудиторий нет.");
                        Console.WriteLine();
                    }
                }
            }

            public void AudList2()
            {
                Console.Clear();
                Console.WriteLine("Введите количество посадочных мест:");
                int pl;
                while (!int.TryParse(Console.ReadLine(), out pl) || pl <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                };

                for (int i = 0; i < currentIndex; i++)
                {
                    if (audArray[i].Places == pl && audArray[i].Projector == "да")
                    {
                        Console.Clear();
                        Console.WriteLine($"Аудитория номер {audArray[i].Auditory}, этаж {audArray[i].Floor}");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Таких аудиторий нет.");
                        Console.WriteLine();
                    }
                }
            }

            public void AudList3()
            {
                Console.Clear();
                Console.WriteLine("Введите количество посадочных мест:");
                int pl;
                while (!int.TryParse(Console.ReadLine(), out pl) || pl <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                };

                for (int i = 0; i < currentIndex; i++)
                {
                    if (audArray[i].Places == pl && audArray[i].Computers == "да")
                    {
                        Console.Clear();
                        Console.WriteLine($"Аудитория номер {audArray[i].Auditory}, этаж {audArray[i].Floor}");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Таких аудиторий нет.");
                        Console.WriteLine();
                    }
                }
            }

            public void AudList4()
            {
                Console.Clear();
                Console.WriteLine("Введите этаж:");
                int fl;
                while (!int.TryParse(Console.ReadLine(), out fl) || fl <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Пожалуйста, введите корректную информацию.\nКоличество посадочных мест:");
                };

                for (int i = 0; i < currentIndex; i++)
                {
                    if (audArray[i].Floor == fl)
                    {
                        Console.Clear();
                        Console.WriteLine($"Аудитория номер {audArray[i].Auditory}.\nКоличество посадочных мест {audArray[i].Places}.\nНаличие прожектора: {audArray[i].Projector}.\nНаличие компьютеров: {audArray[i].Computers}.");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Такого этажа нет.");
                        Console.WriteLine();
                    }
                }
            }

            public void Exit()
            {
                Console.Clear();
            }

        }
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            bool auditoriesFilled = false;

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Заполнить аудиторный фонд.");
                Console.WriteLine("2. Добавить аудиторию.");
                Console.WriteLine("3. Изменить информацию об аудитории.");
                Console.WriteLine("4. Вывести список аудиторий в которых количество посадочных мест больше или равно заданного.");
                Console.WriteLine("5. Вывести список аудиторий с проектором и достаточным количеством мест.");
                Console.WriteLine("6. Вывести список аудиторий с компьютерами и достаточным количеством мест.");
                Console.WriteLine("7. Вывести список аудитроий на заданном этаже.");
                Console.WriteLine("8. Выход.");
                Console.WriteLine();

                string choiceString = Console.ReadLine();
                if (!int.TryParse(choiceString, out int choice))
                {
                    Console.Clear();
                    Console.WriteLine($"Некорректный ввод. Пожалуйста, введите целое число.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        menu.Fill();
                        auditoriesFilled = true;
                        break;
                    case 2:
                        if (auditoriesFilled)
                        {
                            menu.Add();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно заполнить аудиторный фонд.");
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        if (auditoriesFilled)
                        {
                            menu.Change();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно заполнить аудиторный фонд.");
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        if (auditoriesFilled)
                        {
                            menu.AudList1();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно заполнить аудиторный фонд.");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        if (auditoriesFilled)
                        {
                            menu.AudList2();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно заполнить аудиторный фонд.");
                            Console.WriteLine();
                        }
                        break;
                    case 6:
                        if (auditoriesFilled)
                        {
                            menu.AudList3();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно заполнить аудиторный фонд.");
                            Console.WriteLine();
                        }
                        break;
                    case 7:
                        if (auditoriesFilled)
                        {
                            menu.AudList4();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Сначала нужно заполнить аудиторный фонд.");
                            Console.WriteLine();
                        }
                        break;
                    case 8:
                        menu.Exit();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Некорректный выбор. Пожалуйста, выберите существующую операцию.\n");
                        break;
                    }
                }
            }
        }
    }
