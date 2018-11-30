import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "../redux/reduxStore/IState";

import NotFoundScreenComponent from "../screens/NotFoundScreenComponent";

const mapStateToProps = (state: IReduxState) => ({});

const mapDispatchToProps = (dispatch: Dispatch) => ({});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(NotFoundScreenComponent);
