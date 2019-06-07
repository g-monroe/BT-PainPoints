import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import DetailView from './DetailView';

export default (props: any) => {
    const { auth, component: Component, redirect='/login', render, ...rest} = props;
    return (
        <Route {...rest}
            render={(props) => {
                if (auth === "false") {
                    return <Redirect to={{ pathname: redirect, state: { from: props.location } }} />
                }
                else {
                    if (render) {
                        return <DetailView id={props.match.params.id} />
                    } else {
                        return <Component {...props} />
                    }
                }
            }
            }
        />
    ); 
}