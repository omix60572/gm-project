import { type FormEvent, useState } from "react";

interface SearchBarProps {
  onSubmitted?: (searchValue: string) => {};
  placeholder?: string;
}

function SearchBar({ onSubmitted, placeholder }: Readonly<SearchBarProps>) {
  const [searchQuery, setSearchQuery] = useState("");

  const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (onSubmitted !== null && onSubmitted !== undefined)
      onSubmitted(searchQuery);
  };

  const inputPlacaholder =
    placeholder !== null && placeholder !== undefined && placeholder.length > 0
      ? placeholder
      : "Search for movies";

  return (
    <form className="movies-search-form ps-4 pe-4 mt-4" onSubmit={onSubmit}>
      <div className="input-group mb-2 mt-2">
        <input
          id="movies-form-search-input"
          type="text"
          className="form-control"
          placeholder={inputPlacaholder}
          aria-label={inputPlacaholder}
          aria-describedby="button-addon2"
          defaultValue={searchQuery}
          onChange={(e) => setSearchQuery(e.currentTarget.value)}
          onKeyUp={(e) => setSearchQuery(e.currentTarget.value)}
        />
        <button className="btn btn-primary" type="submit" id="button-addon2">
          <i className="bi bi-search me-1"></i>
          Search
        </button>
      </div>
    </form>
  );
}

export default SearchBar;
