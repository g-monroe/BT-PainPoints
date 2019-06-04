import React from 'react';
import { Layout, Form as AntForm, Select, Input, Button, Slider, InputNumber } from 'antd';
import * as yup from 'yup';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';
import { withFormik, InjectedFormikProps, Form } from 'formik';
import { IssueEntity }  from '../entity/CreateFormEntity';
import CreateFormEntity  from '../entity/CreateFormEntity';
import {IPainPointHandler, PainPointHandler } from '../utilities/PainPointHandler';
const { Content } = Layout;
const FormItem = AntForm.Item;

interface ICreateFormProps{
    painPointHandler?: IPainPointHandler;
    handleSave: (entity: IssueEntity) => Promise<void>;
    data: IssueEntity; 
}

interface ICreateFormState{
    Type: string[],
    Title: string,
    Summary: string,
    painPointAnnotation?: string,
    painPointSeverity: number,

    companyName?: string,
    companyContact?: string,
    companyLocation?: string,
    industryType?: string
}

const yupValidation = yup.object().shape<ICreateFormState>({
    Type: yup.array<string>(),
    Title: yup.string().min(2).max(150).required().label('Issue Title'),
    Summary: yup.string().min(2).max(1500).required().label('Issue Summmary'),
    painPointSeverity: yup.number().min(0).max(10).required().label('Issue Severity'),
    painPointAnnotation: yup.string().min(1).max(1500).label('Issue Annotation'),

    companyName: yup.string().label('Company Name'),
    companyContact: yup.string().label('Company Contact'),
    companyLocation: yup.string().label('Company Location'),
    industryType: yup.string().label('Industry Type')
})

class CreateForm extends React.Component<InjectedFormikProps<ICreateFormProps, ICreateFormState>>{
    static defaultProps = {
    };
    
    state = {
        inputValue: 0
    };

    slideChange = (value: any) => {
        this.setState({
            inputValue: value
        });
    };
    handleSave = async (entity: IssueEntity): Promise<void> => {
          await this.props.painPointHandler!.createHero(entity)
      }
    getValidationStatus = (error: any) => {
        return !!error ? 'error' : 'success';
    };

    render() {
        const { values, handleSubmit, errors, handleChange, setFieldValue } = this.props;
        const css = "../src/styles/App.css";
        const { inputValue } = this.state;
        return (
            <Layout>
                <style>
                    {css}
                </style>
                <Content>
                    <Form onSubmitCapture={handleSubmit}>
                        <FormItem label="Issue Title" required validateStatus={this.getValidationStatus(errors.Title)}>
                            <Input id="painPointTitle" placeholder="Title" value={values.Title} onChange={handleChange}/>
                        </FormItem>
                        <FormItem label="Issue Summary" required validateStatus={this.getValidationStatus(errors.Summary)}>
                            <Input id="painPointSummary" placeholder="Description of Problem" value={values.Summary} onChange={handleChange} minLength={3}/>
                        </FormItem>
                        <FormItem label="Issue Annotation" validateStatus={this.getValidationStatus(errors.painPointAnnotation)}>
                            <Input id="painPointAnnotation" placeholder="Personal Notes about Problem" value={values.painPointAnnotation} onChange={handleChange} minLength={3}/>
                        </FormItem>
                        <FormItem label="Issue Type" required validateStatus={this.getValidationStatus(errors.Type)}>
                            <Select mode="multiple" id="painPointType" onChange={x => setFieldValue("painPointType", x)} value={values.Type}>{painPointList.map(p => <Select.Option key={p.id} value={p.id}>{p.name}</Select.Option>)}</Select>
                        </FormItem>
                        <FormItem label="Issue Severity" required validateStatus={this.getValidationStatus(errors.painPointSeverity)}>
                            <Slider id="painPointSeveritySlide" min={0} max={5} onChange={this.slideChange} value={typeof inputValue === 'number' ? inputValue : 0} />
                            <InputNumber id="painPointSeverityVal" min={0} max={5} value={inputValue} onChange={this.slideChange}/>
                        </FormItem>
                        <h3>If filling out an issue for a customer, please include the following:</h3>
                        <FormItem label="Company Contact" validateStatus={this.getValidationStatus(errors.companyContact)}>
                            <Input id="companyContact" placeholder="Company Contact Name" onChange={handleChange} value={values.companyContact}/>
                        </FormItem>
                        <FormItem label="Company Name" validateStatus={this.getValidationStatus(errors.companyName)}>
                            <Input id="companyName" placeholder="Company Name" onChange={handleChange} value={values.companyName}/>
                        </FormItem>
                        <FormItem label="Company Location" validateStatus={this.getValidationStatus(errors.companyLocation)}>
                            <Input id="companyLocation" placeholder="Company Location" onChange={handleChange} value={values.companyLocation}/>
                        </FormItem>
                        <FormItem label="Industry Type" validateStatus={this.getValidationStatus(errors.industryType)}>
                            <Select id="industryType" onChange={x => setFieldValue("industryType", x)} value={values.industryType}>{industryList.map(i => <Select.Option key={i.id} value={i.id}>{i.name}</Select.Option>)}</Select>
                        </FormItem>
                        <Button loading={this.props.isSubmitting} onClick={this.props.handleSubmit} type="primary">
                             Submit test
                        </Button>
                    </Form>
                    <div>
              {JSON.stringify(values)}
            </div>
                </Content>
            </Layout>
        )
    }
};

export default withFormik<ICreateFormProps, ICreateFormState>({
    mapPropsToValues: props => ({
        Id: props.data.Id,
        Type: props.data.Type,
        Title: props.data.Title,
        Summary: props.data.Summary,
        painPointAnnotation: props.data.painPointAnnotation,
        painPointSeverity: props.data.painPointSeverity,
        Status: props.data.Status,
        companyName: props.data.companyName,
        companyContact: props.data.companyContact,
        companyLocation: props.data.companyLocation,
        industryType: props.data.industryType
    }),
    validationSchema: yupValidation,
    handleSubmit: async (values, { setSubmitting, props }) =>  {
        console.log(values);
        await props.handleSave(new IssueEntity(values));
        alert("You have submitted an issue");
        setSubmitting(false);
    },
    displayName: 'Create Issue Form'
})(CreateForm);
