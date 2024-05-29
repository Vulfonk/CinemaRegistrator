const express = require('express');
const cors = require('cors');
const app = express();

// Включаем CORS для всех маршрутов
app.use(cors({
    origin: 'http://localhost:3000'
}));

app.get('/main', (req, res) => {
    // Возвращаем JSON с данными о фильмах
    res.json([
        {
            "startTime": "2024-05-03T02:30:00",
            "filmName": "The Shining",
            "filmID": 1,
            "availiblePlaces": 1,
            "hallNumber": 1,
            "sessionId": 1
        },
        {
            "startTime": "2024-05-03T02:30:00",
            "filmName": "2001: A Space Odyssey",
            "filmID": 3,
            "availiblePlaces": 2,
            "hallNumber": 3,
            "sessionId": 2
        },
        {
            "startTime": "2024-05-03T04:05:00",
            "filmName": "One hundred years ago",
            "filmID": 1,
            "availiblePlaces": 4,
            "hallNumber": 1,
            "sessionId": 3
        },
        {
            "startTime": "2024-05-03T03:45:00",
            "filmName": "GDR",
            "filmID": 0,
            "availiblePlaces": 5,
            "hallNumber": 2,
            "sessionId": 4
        },
        {
            "startTime": "2024-05-03T05:15:00",
            "filmName": "Interstellar",
            "filmID": 0,
            "availiblePlaces": 6,
            "hallNumber": 3,
            "sessionId": 5
        }
    ]);
});

app.get('/infoReserved', (req, res) => {
    const session = req.query.session;
    if (session == 1) {
        // вот почему хочу удалить row (но не только потому что уже в моке нет, просто так проще(и красивее будет в интерфейсе))))
		//бля если будешь спрашивать что недостаточно данных в этом файле. я специально прикрепила фронт. посмотри там по отправлямым запросам (ток js код не открывай)
		//хотя хз сможешь ли ты запустить, я там ридми три раза переписала один хуй не понятно как запускать в первый раз.... не пидарас...
        res.json({
            "sessionId": 1,
            "availableSeats": [1, 2, 3, 4, 5]
        });
    } else {
        res.status(404).json({ error: "Сессия не найдена" });
    }
});

app.post('/bookSeat', (req, res) => {
    // Обработка POST-запроса на бронирование места
    // всегда тру
    
    res.json({ "success": true });
});

const PORT = process.env.PORT || 3003;

app.listen(PORT, () => {
    console.log(`Сервер запущен на порту ${PORT}`);
});
