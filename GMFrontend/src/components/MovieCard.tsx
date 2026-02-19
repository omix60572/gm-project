import imgMoviePlaceholder from "../assets/stock-photo-black-background.jpg";
import { MovieDetailsRoute } from "../common/Routes";
import type MovieCardModel from "../models/MovieCardModel";
import IconButtonWithTooltip from "./common/IconButtonWithTooltip";
import { useEffect, useState } from "react";
import FavoritesStorageFacade from "../facades/FavoritesStorageFacade";
import FavoriteMovie from "../models/FavoriteMovie";
import UrlUtils from "../common/UrlUtils";

interface MovieCardProps {
  model: MovieCardModel;
}

function MovieCard({ model }: Readonly<MovieCardProps>) {
  const favoritesStorageFacade = FavoritesStorageFacade.getInstance();

  const [isFavorite, setIsFavorite] = useState(false);
  const onLikeClick = () => {
    if (isFavorite) {
      setIsFavorite(false);
      favoritesStorageFacade.removeFromFavorites(model.id);
    } else {
      setIsFavorite(true);
      favoritesStorageFacade.addToFavorites(
        new FavoriteMovie(model.id, model.title),
      );
    }
  };

  // Init
  useEffect(() => {
    const initFavoriteStatus = () => {
      const favoriteMovie = favoritesStorageFacade.getFromFavorites(model.id);
      if (favoriteMovie !== null) {
        setIsFavorite(true);
      }
    };

    initFavoriteStatus();
  }, []);

  const openMovieDetailsPage = () => {
    UrlUtils.changeCurrentLocation(
      `${UrlUtils.getCurrentLocation()}/${MovieDetailsRoute}/${model.id}`,
    );
  };

  const movieTitle = model.title.length > 0 ? model.title : "No title";

  return (
    <div className="movie-card card shadow mt-4 ms-4">
      <button
        type="button"
        className="btn p-0 m-0"
        onClick={openMovieDetailsPage}
      >
        <div className="movie-card-img-div">
          <img
            src={
              model.imageUrl !== null &&
              model.imageUrl !== undefined &&
              model.imageUrl.length > 0
                ? model.imageUrl
                : imgMoviePlaceholder
            }
            className="card-img-top"
            alt={movieTitle}
          />
        </div>
      </button>
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
          text={isFavorite ? "Remove from favorites" : "Add to favorites"}
          buttonColor={isFavorite ? "danger" : "primary"}
          buttonIconClass="bi-bookmark-heart-fill"
          onButtonClick={onLikeClick}
        />
        <IconButtonWithTooltip
          text="Mark as viewed"
          buttonColor="primary"
          buttonClass="ms-2"
          buttonIconClass="bi-eyeglasses"
          onButtonClick={() => {}}
        />
        <IconButtonWithTooltip
          text="About the movie"
          buttonColor="primary"
          buttonClass="ms-2"
          buttonIconClass="bi-info-circle-fill"
          onButtonClick={openMovieDetailsPage}
        />
      </div>
    </div>
  );
}

export default MovieCard;
