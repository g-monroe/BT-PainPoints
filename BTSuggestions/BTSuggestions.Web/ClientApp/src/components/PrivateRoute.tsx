import React, { Component } from 'react';
import { Route, Redirect } from 'react-router-dom';

export default (props: any) => {
    const { auth, component: Component, redirect='/login',  ...rest} = props;

    return (
        <Route {...rest}
            render={
                props => auth ?
                    <Component {...props} /> :
                    <Redirect to={{ pathname: redirect, state: {from: props.location} }} />
            }
        />
    ); 
}