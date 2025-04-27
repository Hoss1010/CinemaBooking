// Get movie ID from URL parameters
//const urlParams = new URLSearchParams(window.location.search);
//const movieId = urlParams.get('id');

//// Sample movie data (in a real application, this would come from a backend)
//const movieDetails = {
//    'movie1': {
//        title: 'Paper Towns',
//        poster: 'images/movie5.png',
//        rating: '7.1',
//        duration: '109 min',
//        year: '2015',
//        category: 'Drama',
//        startDate: '2024-02-01',
//        endDate: '2024-02-28',
//        standardPrice: '$10',
//        vipPrice: '$15',
//        director: 'Jake Schreier',
//        genre: 'Mystery, Romance',
//        language: 'English',
//        synopsis: 'After an all-night adventure, Quentin\'s lifelong crush, Margo, disappears, leaving behind clues that Quentin and his friends follow on the journey of a lifetime.',
//        cast: [
//            { name: 'Cara Delevingne', role: 'Margo', image: 'cast1.jpg' },
//            { name: 'Nat Wolff', role: 'Quentin', image: 'cast2.jpg' }
//        ]
//    },
//    'movie2': {
//        title: 'I Origins',
//        poster: 'images/movie6.png',
//        rating: '7.3',
//        duration: '106 min',
//        year: '2014',
//        category: 'Sci-Fi',
//        startDate: '2024-02-15',
//        endDate: '2024-03-15',
//        standardPrice: '$12',
//        vipPrice: '$18',
//        director: 'Mike Cahill',
//        genre: 'Drama, Sci-Fi',
//        language: 'English',
//        synopsis: 'A molecular biologist and his laboratory partner uncover evidence that may fundamentally change society as we know it.',
//        cast: [
//            { name: 'Michael Pitt', role: 'Ian Gray', image: 'cast3.jpg' },
//            { name: 'Brit Marling', role: 'Karen', image: 'cast4.jpg' }
//        ]
//    }
//    // Add more movies as needed
//};

//// Function to populate movie details
//function populateMovieDetails(movieId) {
//    const movie = movieDetails[movieId];
//    if (!movie) {
//        console.error('Movie not found');
//        return;
//    }

//    // Update page title
//    document.title = `${movie.title} - Cinema Booking`;

//    // Update basic info
//    document.getElementById('movie-poster').src = movie.poster;
//    document.getElementById('movie-title').textContent = movie.title;
//    document.getElementById('movie-rating').textContent = movie.rating;
//    document.getElementById('movie-duration').textContent = movie.duration;
//    document.getElementById('movie-year').textContent = movie.year;
//    document.getElementById('movie-category-tag').textContent = movie.category;

//    // Update schedule
//    document.getElementById('start-date').textContent = movie.startDate;
//    document.getElementById('end-date').textContent = movie.endDate;

//    // Update prices
//    document.getElementById('standard-price').textContent = movie.standardPrice;
//    document.getElementById('vip-price').textContent = movie.vipPrice;

//    // Update movie details
//    document.getElementById('movie-synopsis').textContent = movie.synopsis;
//    document.getElementById('movie-director').textContent = movie.director;
//    document.getElementById('movie-genre').textContent = movie.genre;
//    document.getElementById('movie-language').textContent = movie.language;

//    // Populate cast members
//    const castContainer = document.getElementById('cast-members');
//    castContainer.innerHTML = movie.cast.map(member => `
//        <div class="cast-member">
//            <img src="${member.image}" alt="${member.name}">
//            <div class="name">${member.name}</div>
//            <div class="role">${member.role}</div>
//        </div>
//    `).join('');
//}

//// Handle tab switching
//function initializeTabs() {
//    const tabs = document.querySelectorAll('.tab-btn');
//    const tabPanes = document.querySelectorAll('.tab-pane');

//    tabs.forEach(tab => {
//        tab.addEventListener('click', () => {
//            // Remove active class from all tabs and panes
//            tabs.forEach(t => t.classList.remove('active'));
//            tabPanes.forEach(p => p.classList.remove('active'));

//            // Add active class to clicked tab and corresponding pane
//            tab.classList.add('active');
//            const pane = document.getElementById(tab.dataset.tab);
//            pane.classList.add('active');
//        });
//    });
//}

//// Initialize page
//document.addEventListener('DOMContentLoaded', () => {
//    if (movieId) {
//        populateMovieDetails(movieId);
//    }
//    initializeTabs();

//    // Handle booking button click
//    document.querySelector('.book-now-btn').addEventListener('click', () => {
//        // Add booking logic here
//        alert('Booking functionality will be implemented here');
//    });

//    // Handle wishlist button click
//    document.querySelector('.add-to-wishlist').addEventListener('click', function() {
//        const icon = this.querySelector('i');
//        icon.classList.toggle('far');
//        icon.classList.toggle('fas');
//        this.classList.toggle('active');
//    });
//}); 