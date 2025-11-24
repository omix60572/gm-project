import FavoritesView from "../components/FavoritesView";

function Favorites() {
  return (
    <>
      <p className="text-start fs-4 text ms-4 mt-4">Your favorites:</p>
      <FavoritesView searchPlaceholder="Search in favorites" />
    </>
  );
}

export default Favorites;
