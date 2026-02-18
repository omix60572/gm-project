import { useEffect, useState } from "react";
import type MovieCardModel from "../models/MovieCardModel";
import MoviesList from "./MoviesList";
import MovieCardStub from "./MovieCardStub";
import SearchBar from "./SearchBar";
import ErrorBlock from "./common/ErrorBlock";
import MoviesApiService from "../services/MoviesApiService";
import { StringEmpty } from "../common/CommonConst";
import StringUtils from "../common/StringUtils";
import LoggingFacade from "../facades/LoggingFacade";
import Utils from "../common/Utils";

interface MoviesViewProps {
  searchPlaceholder?: string;
}

function MoviesView({ searchPlaceholder }: Readonly<MoviesViewProps>) {
  const [movies, setMovies] = useState<MovieCardModel[]>([]);
  const [error, setError] = useState(StringEmpty);
  const [loading, setLoading] = useState(true);
  const moviesApiService = MoviesApiService.getInstance();
  const logging = LoggingFacade.getInstance();

  // Second param just empty arr, for single call only on component creation (render)
  useEffect(() => {
    const loadPopularMovies = async () => {
      try {
        const popularMoviesResponse: MovieCardModel[] =
          await moviesApiService.getPopularMovies();

        if (!Utils.isNullOrUndefined(popularMoviesResponse)) {
          setMovies(popularMoviesResponse);
        }
      } catch (e) {
        logging.error("Failed to load the movies...", e);
        setError("Failed to load the movies...");
      } finally {
        setLoading(false);
      }
    };

    loadPopularMovies();
  }, []);

  const handleResult = (movies: MovieCardModel[], error: string) => {
    let errorMessage = StringEmpty;

    if (!StringUtils.isEmpty(error)) {
      errorMessage = error;
    } else if (movies === null || movies.length === 0) {
      errorMessage = "Movies list is empty";
    }

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
