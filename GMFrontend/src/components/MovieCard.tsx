import "../components/styles/MovieCard.css";
import imgMoviePlaceholder from "../assets/stock-photo-black-background.jpg";
import type MovieCardModel from "../models/MovieCardModel";
import IconButtonWithTooltip from "./common/IconButtonWithTooltip";

interface MovieCardProps {
  model: MovieCardModel;
}

function MovieCard({ model }: Readonly<MovieCardProps>) {
  const onLikeClick = () => {
    console.log("Like button clicked");
  };

  const movieTitle = model.title.length > 0 ? model.title : "No title";

  return (
    <div className="movie-card card shadow mt-4 ms-4">
      <div className="movie-card-img-div">
        <img
          src={
            model.imageUrl !== null &&
            model.imageUrl !== undefined &&
            model.imageUrl.length > 0
              ? model.imageUrl
              : imgMoviePlaceholder
          }
          className="card-img-top movie-card-img"
          alt={movieTitle}
        />
      </div>
      <div className="card-body">
        <h6 className="card-title movie-card-title-p" title={movieTitle}>
          {movieTitle}
        </h6>
        <p className="card-text movie-card-text-p mb-2">
          {model.description.length > 0 ? model.description : "No description"}
        </p>
        <p className="card-text movie-card-text-release-date-p mb-2">
          Release year: {model.releaseYear}
        </p>
        <IconButtonWithTooltip
          text="Add to favorites"
          buttonColor="primary"
          buttonIconClass="bi-bookmark-heart-fill"
          onButtonClick={onLikeClick}
        />
        <IconButtonWithTooltip
          text="About the movie"
          buttonColor="primary"
          buttonClass="ms-2"
          buttonIconClass="bi-info-circle-fill"
          onButtonClick={() => {}}
        />
        <IconButtonWithTooltip
          text="Mark as viewed"
          buttonColor="primary"
          buttonClass="ms-2"
          buttonIconClass="bi-eyeglasses"
          onButtonClick={() => {}}
        />
      </div>
    </div>
  );
}

export default MovieCard;
