import { AddNewMovieRoute } from "../common/Routes";
import UrlUtils from "../common/UrlUtils";

function AddNewMovieButton() {
  return (
    <button
      type="button"
      className="btn btn-primary"
      onClick={() => {
        UrlUtils.changeCurrentLocation(
          `${UrlUtils.getCurrentLocation()}/${AddNewMovieRoute}`,
        );
      }}
    >
      <i className="bi bi-plus-circle"></i> Add a movie
    </button>
  );
}

export default AddNewMovieButton;
