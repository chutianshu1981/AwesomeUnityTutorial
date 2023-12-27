# Onnx 模型

## 1. 概念

官网给出的定义：ONNX is an open format built to represent machine learning models. ONNX defines a common set of operators - the building blocks of machine learning and deep learning models - and a common file format to enable AI developers to use models with a variety of frameworks, tools, runtimes, and compilers

ONNX 是一种机器学习模型的开放格式。ONNX 定义了一组通用算子（机器学习和深度学习模型的构件）和一种通用文件格式，使人工智能开发人员能够在各种框架、工具、运行时和编译器中使用模型。

## 2. 获取

可以通过多种方式获取 ONNX 格式的模型，其中包括：

* 从网络下载 ： 比如 ：[Onnx 模型下载 ONNX Model Zoo](https://github.com/onnx/models)；或者大名鼎鼎的 [https://huggingface.co/](https://huggingface.co/)

![]()

* ML 训练框架的本机导出：多个训练框架支持针对 ONNX（例如 Chainer、Caffee2 和 PyTorch）的本机导出功能，允许将训练的模型保存为特定版本的 ONNX 格式。 

* 使用 ONNXMLTools 转换现有模型：此 Python 包允许将模型从几个训练框架格式转换为 ONNX。 作为开发人员，你可以指定要将模型转换为哪个版本的 ONNX，具体取决于应用程序针对的 Windows 版本。 

## 3. 用法



> 参考资料 & 资源：
>
> * [ONNX官网](https://onnx.ai/)
> * [微软 windows Onnx 机器学习文档](https://learn.microsoft.com/zh-cn/windows/ai/windows-ml/get-onnx-model)

> * [Onnx 模型下载 ONNX Model Zoo](https://github.com/onnx/models)
