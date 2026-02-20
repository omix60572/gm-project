import UrlUtils from "../common/UrlUtils";
import AddNewMovieCard from "../components/AddNewMovieCard";

function AddNewMovie() {
  return (
    <>
      <div className="pt-4">
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
      <p className="text-start fs-4 text ms-4 mt-4">
        Adding a movie to the library:
      </p>
      <AddNewMovieCard />
    </>
  );
}

export default AddNewMovie;
