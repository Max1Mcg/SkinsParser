# SkinsParser
Приложение для сравнения цен на скины cs go с разных сайтов.
На данный момент цены на скины берутся с csgotm, csmoney и steam market, основной функционал реализован в методах .GetItem() для классов-Worker`ов.
В классе DollarRate парсится сайт цб и оттуда берётся курс доллара на текущий момент.
Изначально установлены 3 параметра для поиска, их можно поменять. При отсутствии предмета или неверном запросе будет выведено сообщение об ошибке,
информирующее пользователя об этом. Если всё сработает правильно, то будет возвращена ссылка на сайт с наименьшей ценой для искомого предмета.
