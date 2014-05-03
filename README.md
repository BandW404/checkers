checkers
========
На этой неделе вам предстоит написать "искуственный интеллект" для игры в шашки. Нет, это никак не связано с графами.
Для вас нами написана платформа со всеми нужными классами и интерфейсами, вам только нужно написать один класс, поддерживающий интерфейс IPlayer. 
    Это можно сделать прямо в нашем проекте TestPlayer. Там же вы можете ознакомиться с самым простым примером ИИ (полный рандом по правилам). Ваш ИИ должен уверенно (хотя бы 3 из 5 игр стабильно) выигрывать у нашего тестового. После того, как вы напишите ваш метод, вам нужно будет собрать этот проект (правой кнопкой на TestPlayer, build). 
    После этого в папке TestPlayer/bin/Debug появится файл TestPlayer.dll. Его переиминуйте в вашу фамилию (например Zagnoiko.dll) и попробуйте запустить его против нашего тестового интерфейса. Для этого вам понадобится поместить его в папку Checkers.Tournament/bin/Debug и Checkers.Runner/bin/Debug. Затем просто измените в студии аргументы запуска проекта Tournament (это можно сделать в меню PROJECT, properties, debug). Там поле аргументы, нужно два -- TestPlayer.dll и ваш.dll.
Третьим аргументом можно указать true, если вы хотите увидеть игру против ИИ в интерфейсе формы. 
    Вся информация об игре будет сохраняться в логах, по адресу Checkers.Tournament\bin\Debug\Logs.txt . Его открывайте Sublime или Notepad++. 
    В этом файле хранится информация о совершенных вами и противником ходах, о возможных ошибках, о победах или поражениях.
Почитать правила игры вы можете по ссылке внизу. За соблюдением игры будет следить класс Валидатор, который написан в проекте Checkers. Вы можете поглядеть как он работает, поискать изъяны ;) В случае неверного хода, вам будет кинут эксепшн и в логи будет записана информация об ошибке (если кое-кто это таки реализовал). 
    Так же рекомендуется ознакомиться со всеми классами в проекте Checkers, т.к. большинство из них вам придется использовать. Остальные проекты нужны только для отсечения читерства и всего такого, они не особо важны для вас.
    Удачи :3

========

Сейчас на первой неделе ваша основная задача разобраться с кодом, придумать какой-нибудь алгоритм выбора ходов, и, возможно, начать его реализовывать. На ближайшей практике у вас будет возможность задать интересующие вопросы по коду, обсудить возможные алгоритмы(только тихо, ваши враги могут услышать).

    Сами условия турнира будут определены позднее.

    Правила шашек: <url>http://tinyurl.com/ocfyq4g</url>
