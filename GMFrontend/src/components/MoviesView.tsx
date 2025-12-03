import { useEffect, useState } from "react";
import type MovieCardModel from "../models/MovieCardModel";
import { getPopularMovies } from "../services/MoviesApiService";
import MoviesList from "./MoviesList";
import MovieCardStub from "./MovieCardStub";
import SearchBar from "./SearchBar";

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
          await getPopularMovies();

        if (
          popularMoviesResponse !== null &&
          popularMoviesResponse !== undefined
        )
          setMovies(popularMoviesResponse);
      } catch (e) {
        console.log(e);
        setError("Falied to load movies...");
      } finally {
        setLoading(false);
      }
    };

    loadPopularMovies();
  }, []);

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
        <MoviesList movies={movies} />
      )}
    </>
  );
}

export default MoviesView;
