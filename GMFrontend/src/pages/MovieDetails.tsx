import { useEffect, useState } from "react";
import SelectedMovieDetailsStub from "../components/SelectedMovieDetailsStub";
import { getMovieById } from "../services/MoviesApiService";
import SelectedMovieDetails from "../components/SelectedMovieDetails";
import type MovieCardModel from "../models/MovieCardModel";
import ErrorBlock from "../components/common/ErrorBlock";

function MovieDetails() {
  const urlsParts = document.URL.split("/");
  let movieIdStr = urlsParts.at(-1);
  movieIdStr ??= "-1";

  const movieId = Number.parseInt(movieIdStr);

  const [movie, setMovie] = useState<MovieCardModel>();
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadMovie = async () => {
      try {
        const movieResponse: MovieCardModel = await getMovieById(movieId);
        if (movieResponse !== null && movieResponse !== undefined) {
          setMovie(movieResponse);
        }
      } catch (e) {
        console.log(e);
        setError("Failed to load the movie details...");
      } finally {
        setLoading(false);
      }
    };

    loadMovie();
  }, []);

  const handleResult = (movie: MovieCardModel, error: string) => {
    let errorMessage = "";

    if (error !== null && error !== undefined && error !== "")
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
            globalThis.history.go(-1);
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
