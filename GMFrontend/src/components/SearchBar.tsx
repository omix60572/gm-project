import { type FormEvent, useState } from "react";
import { StringEmpty } from "../common/CommonConst";
import Utils from "../common/Utils";
import StringUtils from "../common/StringUtils";
import LoggingFacade from "../facades/LoggingFacade";

interface SearchBarProps {
  onSubmitted?: (searchValue: string) => {};
  placeholder?: string;
}

function SearchBar({ onSubmitted, placeholder }: Readonly<SearchBarProps>) {
  const [searchQuery, setSearchQuery] = useState(StringEmpty);
  const logging = LoggingFacade.getInstance();

  const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const result = Utils.tryInvoke<string>(onSubmitted, searchQuery);
    if (!StringUtils.isEmpty(result)) {
      logging.error(result!);
    }
  };

  let inputPlaceholder = "Search for movies"
  if (!StringUtils.isEmpty(placeholder)) {
    inputPlaceholder = placeholder!;
  }

  return (
    <form className="movies-search-form mt-4" onSubmit={onSubmit}>
      <div className="input-group mb-2 mt-2">
        <input
          id="movies-form-search-input"
          type="text"
          className="form-control"
          placeholder={inputPlaceholder}
          aria-label={inputPlaceholder}
          aria-describedby="button-addon2"
          defaultValue={searchQuery}
          onChange={(e) => setSearchQuery(e.currentTarget.value)}
          onKeyUp={(e) => setSearchQuery(e.currentTarget.value)}
        />
        <button className="btn btn-primary" type="submit" id="button-addon2">
          <i className="bi bi-search me-1"></i> Search
        </button>
      </div>
    </form>
  );
}

export default SearchBar;
