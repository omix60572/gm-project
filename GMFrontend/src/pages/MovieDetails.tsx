import { useEffect, useState } from "react";
import SelectedMovieDetailsStub from "../components/SelectedMovieDetailsStub";
import SelectedMovieDetails from "../components/SelectedMovieDetails";
import MovieCardModel from "../models/MovieCardModel";
import ErrorBlock from "../components/common/ErrorBlock";
import MoviesApiService from "../services/MoviesApiService";
import { StringEmpty } from "../common/CommonConst";
import UrlUtils from "../common/UrlUtils";
import LoggingFacade from "../facades/LoggingFacade";
import Utils from "../common/Utils";
import StringUtils from "../common/StringUtils";

// TODO: Добавить кнопки по работе с добавлением в избранное и так далее
function MovieDetails() {
  const urlsParts = document.URL.split("/");
  let movieIdStr = urlsParts.at(-1);
  movieIdStr ??= "-1";

  const movieId = Number.parseInt(movieIdStr);

  const [movie, setMovie] = useState<MovieCardModel>();
  const [error, setError] = useState(StringEmpty);
  const [loading, setLoading] = useState(true);
  const moviesApiService = MoviesApiService.getInstance();
  const logging = LoggingFacade.getInstance();

  useEffect(() => {
    const loadMovie = async () => {
      try {
        const movieResponse: MovieCardModel =
          await moviesApiService.getMovieById(movieId);
        if (!Utils.isNullOrUndefined(movieResponse)) {
          setMovie(movieResponse);
        }
      } catch (error) {
        logging.error("Failed to load the movie details...", error);
        setError("Failed to load the movie details...");
      } finally {
        setLoading(false);
      }
    };

    loadMovie();
  }, []);

  const handleResult = (movie: MovieCardModel | undefined, errorString: string) => {
    let errorMessage = StringEmpty;

    if (!StringUtils.isEmpty(errorString)) {
      errorMessage = errorString;
    } else if (movie === null || movie === undefined) {
      errorMessage = "The movie was not found...";
    }

    return errorMessage.length > 0 ? (
      <ErrorBlock text={errorMessage} />
    ) : (
      <SelectedMovieDetails movie={movie ?? MovieCardModel.getDefault()} />
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
      {loading ? <SelectedMovieDetailsStub /> : handleResult(movie, error)}
    </>
  );
}

export default MovieDetails;
