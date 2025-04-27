//// Sample movie data
//const movies = [
//    {
//        title: 'Paper Towns',
//        year: 2015,
//        genre: 'Fiction, Drama',
//        poster: 'images/movie5.png',
//        rating: 7.1,
//        available: true
//    },
//    {
//        title: 'I Origins',
//        year: 2014,
//        genre: 'Science Fiction',
//        poster: 'images/movie6.png',
//        rating: 7.3,
//        available: false
//    },
//    {
//        title: 'The Perks of Being a Wallflower',
//        year: 2012,
//        genre: 'Drama, Romance',
//        poster: 'images/movie7.png',
//        rating: 7.8,
//        available: true
//    },
//    {
//        title: 'Inside Out',
//        year: 2015,
//        genre: 'Animation, Family',
//        poster: 'images/movie8.png',
//        rating: 8.2,
//        available: true
//    },
//    // Add more movies as needed
//];

//// Sample news data
//const news = [
//    {
//        title: 'Suicide Squad Is a Hit, But DC Needs to Start Making Better Movies',
//        image: 'suicide-squad.jpg',
//        timestamp: '2 Hours Ago',
//        author: 'by Yogi'
//    },
//    // Add more news items as needed
//];

//// Sample reviewer data
//const reviewers = [
//    {
//        name: 'Emma Freeman',
//        avatar: 'emma.jpg',
//        reviews: 3112
//    },
//    // Add more reviewers as needed
//];

//// Initialize the page
//document.addEventListener('DOMContentLoaded', () => {
//    initializeMovieGrid();
//    initializeNewsGrid();
//    initializeReviewers();
//    initializeSlider();
//    initializeSearch();
//    initializeFilterTabs();
//});

//// Function to initialize the movie grid
//function initializeMovieGrid() {
//    const moviesGrid = document.querySelector('.movies-grid');
    
//    movies.forEach(movie => {
//        const movieElement = createMovieCard(movie);
//        moviesGrid.appendChild(movieElement);
//    });
//}

//// Function to create a movie card
//function createMovieCard(movie) {
//    const div = document.createElement('div');
//    div.className = 'movie-thumbnail';
//    div.innerHTML = `
//        <img src="${movie.poster}" alt="${movie.title}">
//        <span class="availability-badge ${movie.available ? 'available' : 'unavailable'}">
//            ${movie.available ? 'Available' : 'Unavailable'}
//        </span>
//        <div class="movie-info">
//            <h3>${movie.title}</h3>
//            <p>${movie.year} | ${movie.genre}</p>
//            <div class="rating">${movie.rating}</div>
//        </div>
//        <div class="card-buttons">
//            <button class="book-now-btn" ${!movie.available ? 'disabled' : ''}>
//                Book Now
//            </button>
//            <button class="details-btn" data-movie-id="movie${movies.indexOf(movie) + 1}">
//                Details
//            </button>
//        </div>
//    `;

//    // Add event listeners for buttons
//    const bookBtn = div.querySelector('.book-now-btn');
//    const detailsBtn = div.querySelector('.details-btn');

//    bookBtn.addEventListener('click', () => {
//        if (movie.available) {
//            alert(`Booking movie: ${movie.title}`);
//            // Add your booking logic here
//        }
//    });

//    //detailsBtn.addEventListener('click', (e) => {
//    //   const movieId = e.target.dataset.movieId;
//    //    window.location.href = `https://localhost:7017/Home/Details?id=movie1`; 
//    //});

//    return div;
//}

//// Initialize the slider
//function initializeSlider() {
//    const prevBtn = document.querySelector('.prev-btn');
//    const nextBtn = document.querySelector('.next-btn');
//    const slides = document.querySelectorAll('.featured-movie');
//    let currentSlide = 0;

//    function showSlide(index) {
//        slides.forEach(slide => slide.classList.remove('active'));
//        slides[index].classList.add('active');
//    }

//    prevBtn.addEventListener('click', () => {
//        currentSlide = (currentSlide - 1 + slides.length) % slides.length;
//        showSlide(currentSlide);
//    });

//    nextBtn.addEventListener('click', () => {
//        currentSlide = (currentSlide + 1) % slides.length;
//        showSlide(currentSlide);
//    });
//}

//// Initialize search functionality
//function initializeSearch() {
//    const searchInput = document.querySelector('.search-bar input');
    
//    searchInput.addEventListener('input', (e) => {
//        const searchTerm = e.target.value.toLowerCase();
//        const movieCards = document.querySelectorAll('.movie-thumbnail');
        
//        movieCards.forEach(card => {
//            const title = card.querySelector('h3').textContent.toLowerCase();
//            if (title.includes(searchTerm)) {
//                card.style.display = 'block';
//            } else {
//                card.style.display = 'none';
//            }
//        });
//    });
//}

//// Initialize filter tabs
//function initializeFilterTabs() {
//    const filterButtons = document.querySelectorAll('.filter-tabs button');
    
//    filterButtons.forEach(button => {
//        button.addEventListener('click', () => {
//            filterButtons.forEach(btn => btn.classList.remove('active'));
//            button.classList.add('active');
            
//            // Add filtering logic here based on the selected tab
//            const filter = button.textContent.toLowerCase();
//            filterMovies(filter);
//        });
//    });
//}

//// Filter movies based on selected tab
//function filterMovies(filter) {
//    const movieCards = document.querySelectorAll('.movie-thumbnail');
    
//    // Add your filtering logic here
//    // This is just a sample implementation
//    movieCards.forEach(card => {
//        if (filter === 'random') {
//            card.style.display = 'block';
//        } else if (filter === 'popular') {
//            const rating = parseFloat(card.querySelector('.rating').textContent);
//            card.style.display = rating >= 7.5 ? 'block' : 'none';
//        } else if (filter === 'recent') {
//            const year = parseInt(card.querySelector('p').textContent.split('|')[0]);
//            card.style.display = year >= 2020 ? 'block' : 'none';
//        }
//    });
//}

//// Initialize news grid
//function initializeNewsGrid() {
//    const newsGrid = document.querySelector('.news-grid');
    
//    news.forEach(item => {
//        const newsElement = createNewsCard(item);
//        newsGrid.appendChild(newsElement);
//    });
//}

//// Create news card
//function createNewsCard(news) {
//    const div = document.createElement('div');
//    div.className = 'news-card';
//    div.innerHTML = `
//        <img src="${news.image}" alt="${news.title}">
//        <div class="news-content">
//            <span class="timestamp">${news.timestamp} ${news.author}</span>
//            <h3>${news.title}</h3>
//            <a href="#" class="read-more">Read Full Article</a>
//        </div>
//    `;
//    return div;
//}

//// Initialize reviewers section
//function initializeReviewers() {
//    const reviewersSection = document.querySelector('.top-reviewers');
    
//    reviewers.forEach(reviewer => {
//        const reviewerElement = createReviewerCard(reviewer);
//        reviewersSection.appendChild(reviewerElement);
//    });
//}

//// Create reviewer card
//function createReviewerCard(reviewer) {
//    const div = document.createElement('div');
//    div.className = 'reviewer-card';
//    div.innerHTML = `
//        <img src="${reviewer.avatar}" alt="${reviewer.name}">
//        <h3>${reviewer.name}</h3>
//        <p>${reviewer.reviews} reviews</p>
//    `;
//    return div;
//}

//// Add smooth scrolling for navigation links
//document.querySelectorAll('a[href^="#"]').forEach(anchor => {
//    anchor.addEventListener('click', function (e) {
//        e.preventDefault();
//        document.querySelector(this.getAttribute('href')).scrollIntoView({
//            behavior: 'smooth'
//        });
//    });
//}); 