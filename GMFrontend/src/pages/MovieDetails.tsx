import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import SelectedMovieDetailsStub from "../components/SelectedMovieDetailsStub";
import { getMovieById } from "../services/MoviesApiService";
import SelectedMovieDetails from "../components/SelectedMovieDetails";
import type MovieCardModel from "../models/MovieCardModel";

function MovieDetails() {
  let { movieIdStr } = useParams();
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
        setError("Failed to load movie...");
      } finally {
        setLoading(false);
      }
    };

    loadMovie();
  }, []);

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
      {loading ? (
        <SelectedMovieDetailsStub />
      ) : (
        <SelectedMovieDetails movie={movie!} />
      )}
    </>
  );
}

export default MovieDetails;
