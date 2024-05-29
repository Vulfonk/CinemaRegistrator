document.addEventListener('DOMContentLoaded', () => {
    const movieList = document.querySelector('.movie-list');

    // Function to fetch movie data from the provided URL
    const fetchMovieData = async () => {
        try {
            const response = await fetch('https://localhost:7056/NearestSessions?date=2024-05-03%2005%3A15');
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const movies = await response.json();
            displayMovies(movies);
        } catch (error) {
            console.error('Failed to fetch movie data:', error);
        }
    };

    // Function to display movies
    const displayMovies = (movies) => {
        movies.forEach(movie => {
            const movieItem = document.createElement('div');
            movieItem.classList.add('movie-item');

            const title = document.createElement('h2');
            title.textContent = movie.filmName;
            movieItem.appendChild(title);

            const details = document.createElement('p');
            details.textContent = `Зал ${movie.hallNumber}, ${new Date(movie.startTime).toLocaleTimeString([], {hour: '2-digit', minute:'2-digit'})}`;
            movieItem.appendChild(details);

            const showtimes = document.createElement('div');
            showtimes.classList.add('showtimes');

            const showtime = document.createElement('div');
            showtime.classList.add('showtime');
            showtime.textContent = `Начало: ${new Date(movie.startTime).toLocaleTimeString([], {hour: '2-digit', minute:'2-digit'})}`;
             showtime.dataset.sessionId = movie.sessionId;
                showtime.addEventListener('click', () => {
                    window.location.href = `booking.html?sessionId=${movie.sessionId}`;
                });
            showtimes.appendChild(showtime);

            movieItem.appendChild(showtimes);
            movieList.appendChild(movieItem);
        });
    };

    // Fetch and display movie data
    fetchMovieData();
});
