import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "../redux/reduxStore/IState";

import ProfileScreenComponent from "../screens/ProfileScreenComponent";

const mapStateToProps = (state: IReduxState) => ({});

const mapDispatchToProps = (dispatch: Dispatch) => ({});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ProfileScreenComponent);
