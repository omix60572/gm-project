import imgMoviePlaceholder from "../assets/stock-photo-black-background.jpg";

function AddNewMovieCard() {
  return (
    <div className="w-100 text-center">
      <div className="card mb-5 mt-4 new-movie-wide-card-div">
        <div className="row g-0">
          <div className="col-md-3">
            <img
              src={imgMoviePlaceholder}
              className="card-img"
              alt="Movie poster"
            />
          </div>
          <div className="col-md-9">
            <div className="card-body ps-4 pt-4">
              <p className="text-start">Movie title:</p>
              <div className="input-group mb-3">
                <input
                  type="text"
                  className="form-control"
                  placeholder="Movie title"
                  aria-label="Movie title"
                  aria-describedby="basic-addon1"
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default AddNewMovieCard;
