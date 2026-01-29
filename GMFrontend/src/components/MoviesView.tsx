import { useEffect, useState } from "react";
import type MovieCardModel from "../models/MovieCardModel";
import MoviesList from "./MoviesList";
import MovieCardStub from "./MovieCardStub";
import SearchBar from "./SearchBar";
import ErrorBlock from "./common/ErrorBlock";
import { moviesApiService } from "../services/MoviesApiService";

interface MoviesViewProps {
  searchPlaceholder?: string;
}

function MoviesView({ searchPlaceholder }: Readonly<MoviesViewProps>) {
  const [movies, setMovies] = useState<MovieCardModel[]>([]);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  // Second param just empty arr, for single call only on component creation (render)
  useEffect(() => {
    const loadPopularMovies = async () => {
      try {
        const popularMoviesResponse: MovieCardModel[] =
          await moviesApiService.getPopularMovies();

        if (
          popularMoviesResponse !== null &&
          popularMoviesResponse !== undefined
        )
          setMovies(popularMoviesResponse);
      } catch (e) {
        console.log(e);
        setError("Failed to load the movies...");
      } finally {
        setLoading(false);
      }
    };

    loadPopularMovies();
  }, []);

  const handleResult = (movies: MovieCardModel[], error: string) => {
    let errorMessage = "";

    if (error !== null && error !== undefined && error !== "")
      errorMessage = error;
    else if (movies === null || movies.length === 0)
      errorMessage = "Movies list is empty";

    return errorMessage.length > 0 ? (
      <ErrorBlock text={errorMessage} />
    ) : (
      <MoviesList movies={movies} />
    );
  };

  const timeKeyOffset = Date.now();
  return (
    <>
      <SearchBar placeholder={searchPlaceholder} />
      {loading ? (
        <div className="d-inline-block">
          {Array.from({ length: 10 }).map((_, index) => (
            <MovieCardStub key={timeKeyOffset + index} />
          ))}
        </div>
      ) : (
        handleResult(movies, error)
      )}
    </>
  );
}

export default MoviesView;
