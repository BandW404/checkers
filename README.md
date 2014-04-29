checkers
========
На этой неделе вам предстоит написать "искуственный интеллект" для игры в шашки. Нет, это никак не связано с графами.
Для вас нами написана платформа со всеми нужными классами и интерфейсами, вам только нужно написать один класс, поддерживающий интерйейс IPlayer. Это можно сделать прямо в нашем проекте в разделе TestPlayer. Там же вы можете ознакомиться с самым простым примером ИИ (полный рандом по правилам). Ваш ИИ должен уверенно (хотя бы 4 из 5 игр более-менее стабильно) выигрывать у нашего тестового. После того, как вы напишите ваш метод, вам нужно будет собрать этот проект (правой кнопкой на TestPlayer, build). После этого в папке TestPlayer/bin/Debug появится файл TestPlayer.dll. Его переиминуйте в вашу фамилию (например Zagnoiko.dll) и попробуйте запустить его против нашего тестового интерфейса. Для этого вам понадобится поместить его в папку Checkers.Tournament/bin/Debug. Затем просто измените в студии аргументы запуска проекта Tournament (это можно сделать в меню PROJECT, properties, debug. там поле аргументы, нужно два -- TestPlayer.dll и ваш.dll) .
Третьим аргументом можно указать true, если вы хотите увидеть игру против ИИ в интерфейсе формы. 
Вся информация об игре будет сохряться в логах, по адресу Checkers.Tournament\bin\Debug\Logs.txt . Его открывайте Sublime или Notepad++. 
