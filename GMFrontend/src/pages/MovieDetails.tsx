import { useEffect, useState } from "react";
import SelectedMovieDetailsStub from "../components/SelectedMovieDetailsStub";
import SelectedMovieDetails from "../components/SelectedMovieDetails";
import type MovieCardModel from "../models/MovieCardModel";
import ErrorBlock from "../components/common/ErrorBlock";
import MoviesApiService from "../services/MoviesApiService";
import { StringEmpty } from "../common/CommonConst";
import UrlUtils from "../common/UrlUtils";
import LoggingFacade from "../facades/LoggingFacade";

// TODO: Добавить кнопки по работе с добавлением в избранное и так далее
function MovieDetails() {
  const logging = LoggingFacade.getInstance();
  const urlsParts = document.URL.split("/");
  let movieIdStr = urlsParts.at(-1);
  movieIdStr ??= "-1";

  const movieId = Number.parseInt(movieIdStr);

  const [movie, setMovie] = useState<MovieCardModel>();
  const [error, setError] = useState(StringEmpty);
  const [loading, setLoading] = useState(true);
  const moviesApiService = MoviesApiService.getInstance();

  useEffect(() => {
    const loadMovie = async () => {
      try {
        const movieResponse: MovieCardModel = await moviesApiService.getMovieById(movieId);
        if (movieResponse !== null && movieResponse !== undefined) {
          setMovie(movieResponse);
        }
      } catch (e) {
        logging.error("Failed to load the movie details...", e);
        setError("Failed to load the movie details...");
      } finally {
        setLoading(false);
      }
    };

    loadMovie();
  }, []);

  const handleResult = (movie: MovieCardModel, error: string) => {
    let errorMessage = StringEmpty;

    if (error !== null && error !== undefined && error !== StringEmpty)
      errorMessage = error;
    else if (movie === null || movie === undefined)
      errorMessage = "The movie was not found...";

    return errorMessage.length > 0 ? (
      <ErrorBlock text={errorMessage} />
    ) : (
      <SelectedMovieDetails movie={movie} />
    );
  };

  return (
    <>
      <div className="selected-movie-details-top-buttons-div pt-4">
        <button
          type="button"
          className="btn btn-primary"
          onClick={() => {
            UrlUtils.goBack();
          }}
        >
          <i className="bi bi-arrow-left me-1"></i> Go back
        </button>
      </div>
      {loading ? <SelectedMovieDetailsStub /> : handleResult(movie!, error)}
    </>
  );
}

export default MovieDetails;
