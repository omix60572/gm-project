import "./styles/TopMenuBar.css";
import logoSmall from "../assets/logo-small.png";

interface TopMenuBarProps {
  switchTheme: () => void;
}

function TopMenuBar({ switchTheme }: Readonly<TopMenuBarProps>) {
  return (
    <nav
      className="navbar bg-primary rounded-bottom shadow"
      data-bs-theme="dark"
    >
      <div className="container-fluid justify-content-start">
        <a className="navbar-brand" href="/">
          <img
            src={logoSmall}
            alt="Logo"
            width="30"
            height="30"
            className="d-inline-block align-text-top me-1"
          />
          Good Movies are here
        </a>
        <ul className="nav">
          <li className="nav-item">
            <a className="nav-link text-light-emphasis" href="/">
              <i className="bi bi-house-fill me-1"></i>
              Home
            </a>
          </li>
          <li className="nav-item">
            <a className="nav-link text-light-emphasis" href="/favorites">
              <i className="bi bi-house-heart-fill me-1"></i>
              Favorites
            </a>
          </li>
        </ul>
        <button
          type="button"
          className="btn btn-warning top-menu-theme-switch-btn"
          onClick={switchTheme}
        >
          Switch theme
        </button>
      </div>
    </nav>
  );
}

export default TopMenuBar;
