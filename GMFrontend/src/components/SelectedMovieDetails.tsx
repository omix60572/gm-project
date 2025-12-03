import type MovieCardModel from "../models/MovieCardModel";
import imgMoviePlaceholder from "../assets/stock-photo-black-background.jpg";

interface SelectedMovieDetailsProps {
  movie: MovieCardModel;
}

function SelectedMovieDetails({ movie }: Readonly<SelectedMovieDetailsProps>) {
  return (
    <div className="selected-movie-wide-card-page-root-div">
      <div className="card mb-5 mt-4 selected-movie-wide-card-div">
        <div className="row g-0">
          <div className="col-md-3">
            <img
              src={
                movie.imageUrl !== null &&
                movie.imageUrl !== undefined &&
                movie.imageUrl.length > 0
                  ? movie.imageUrl
                  : imgMoviePlaceholder
              }
              className="card-img-top"
              alt={movie.title}
            />
          </div>
          <div className="col-md-9">
            <div className="card-body ps-4 pt-4">
              <h3 className="card-title pb-3">{movie.title}</h3>
              <p className="card-text">{movie.description}</p>
              <p className="card-text">
                <small className="text-body-secondary">
                  Release year: {movie.releaseYear}
                </small>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default SelectedMovieDetails;
