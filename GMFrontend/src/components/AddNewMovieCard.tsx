import imgMoviePlaceholder from "../assets/stock-photo-black-background.jpg";

function AddNewMovieCard() {
  return (
    <div className="card mb-5 mt-4 new-movie-wide-card-div">
      <div className="row g-0 p-4">
        <div className="col-md-3">
          <img
            src={imgMoviePlaceholder}
            className="card-img"
            alt="Movie poster"
          />
        </div>
        <div className="form-container col-md-9 ps-4">
          <form action="/submit-movie" method="POST" encType="multipart/form-data">
            <div className="mb-3">
              <label htmlFor="title" className="form-label">
                Movie Title
              </label>
              <input
                type="text"
                className="form-control"
                id="title"
                name="title"
                placeholder="Enter the movie title"
                required
                autoComplete="off"
              />
            </div>
            <div className="mb-3">
              <label htmlFor="description" className="form-label">
                Description
              </label>
              <textarea
                className="form-control"
                id="description"
                name="description"
                rows={4}
                placeholder="Write a short description..."
                required
              ></textarea>
            </div>
            <div className="mb-3">
              <label htmlFor="imageUrl" className="form-label">
                Poster image URL
              </label>
              <input
                type="url"
                className="form-control"
                id="imageUrl"
                name="imageUrl"
                placeholder="https://example.com/poster.jpg"
                autoComplete="off"
              />
            </div>
            <div className="mb-3">
              <label htmlFor="imageUrl" className="form-label">
                Data source URL
              </label>
              <input
                type="url"
                className="form-control"
                id="dataSourceUrl"
                name="dataSourceUrl"
                placeholder="https://example.com/movie"
                autoComplete="off"
              />
            </div>
            <div className="d-grid">
              <button type="submit" className="btn btn-primary">
                Add a movie
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default AddNewMovieCard;
