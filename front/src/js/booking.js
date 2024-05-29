document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const sessionId = urlParams.get('sessionId');
    console.log(`Parsed session ID: ${sessionId}`); // Add log here

    if (!sessionId) {
        alert('Invalid session ID');
        return;
    }

    const seatsContainer = document.getElementById('seats');

    fetch(`https://localhost:7056/infoReserved?session=${sessionId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            if (data && data.availableSeats) {
                data.availableSeats.forEach(seatNumber => {
                    const seat = document.createElement('div');
                    seat.classList.add('seat');
                    seat.textContent = `Место ${seatNumber}`;
                    seat.addEventListener('click', () => {
                        bookSeat(seatNumber, sessionId);
                    });
                    seatsContainer.appendChild(seat);
                });
            } else {
                seatsContainer.textContent = 'Нет доступных мест';
            }
        })
        .catch(error => {
            console.error('Error fetching seats:', error);
            seatsContainer.textContent = 'Произошла ошибка при загрузке мест';
        });
});

function bookSeat(seatNumber, sessionId) {
    fetch('https://localhost:7056/bookSeat', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            place: seatNumber,
            session: sessionId
        }),
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then(data => {
        if (data.success) {
            alert(`Вы забронировали место ${seatNumber}`);
        } else {
            alert('Не удалось забронировать место');
        }
    })
    .catch(error => {
        console.error('Error booking seat:', error);
        alert('Произошла ошибка при бронировании места');
    });
}
