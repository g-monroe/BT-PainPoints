import React from 'react';
import { Layout } from 'antd';
import * as yup from 'yup';
import { withFormik, InjectedFormikProps, Form } from 'formik';

const { Content } = Layout;

interface ICreateFormProps{

}

interface ICreateFormState{
    painPointId?: number,
    painPointType: string,
    painPointTitle: string,
    painPointSummary: string,
    painPointAnnotation?: string,
    painPointSeverity: number,

    submissionStatus: string,

    companyName?: string,
    companyContact?: string,
    companyLocation?: string,
    industryType?: string,

    userId?: number,
    userName: string
}

/* const yupValidation = yup.object().shape<ICreateFormState>({
    painPointId: yup.number().lessThan(150).moreThan(2),
    painPointType:
    painPointTitle: string,
    painPointSummary: string,
    painPointAnnotation?: string,
    painPointSeverity: number,

    submissionStatus: string,

    companyName?: string,
    companyContact?: string,
    companyLocation?: string,
    industryType?: string,

    userId?: number,
    userName: string

}) */
