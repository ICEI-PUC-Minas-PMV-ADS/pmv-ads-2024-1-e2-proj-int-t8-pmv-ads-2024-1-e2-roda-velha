# Especificações do Projeto

## Personas

### Entusiasta casual
<table>
  <tr>
    <th>Descrição</th>
    <td>Indivíduos que possuem interesse em carros clássicos, mas ainda não estão profundamente envolvidos na comunidade. Eles gostam de admirar esses veículos em exposições e eventos, mas não têm tempo ou recursos para se tornarem colecionadores ativos.</td>
  </tr>
  <tr>
    <th>Necessidades</th>
    <td>
      Encontrar eventos de carros clássicos próximos à sua localização para participar ocasionalmente. Desejam informações sobre os tipos de carros exibidos e a atmosfera geral do evento para decidir se vale a pena comparecer. 
    </td>
  </tr>
</table>

### Colecionador entusiasta 
<table>
  <tr>
    <th>Descrição</th>
    <td>Indivíduos apaixonados por carros clássicos que dedicam tempo e recursos significativos à sua coleção. Eles participam ativamente de eventos, leilões e encontros de carros clássicos, e estão sempre em busca de oportunidades para expandir sua coleção e interagir com outros entusiastas.</td>
  </tr>
  <tr>
    <th>Necessidades</th>
    <td>
      Encontrar eventos de alto nível que apresentem carros raros e exclusivos. Além disso, desejam saber detalhes sobre os organizadores, expositores e qualquer programa especial oferecido durante o evento. 
    </td>
  </tr>
</table>

### Organizador de eventos
<table>
  <tr>
    <th>Descrição</th>
    <td>Indivíduos ou empresas que planejam e promovem exposições, leilões e outros eventos relacionados a carros clássicos. Eles estão focados em atrair participantes e expositores de qualidade para garantir o sucesso do evento.</td>
  </tr>
  <tr>
    <th>Necessidades</th>
    <td>
      Divulgar seu evento para atrair um público amplo e qualificado. Eles buscam uma plataforma confiável para listar seu evento, gostariam de um mecanismo de likes nos eventos criados. 
    </td>
  </tr>
</table>

### Colecionador entusiasta 
<table>
  <tr>
    <th>Descrição</th>
    <td>Empresas ou indivíduos que compram, vendem e negociam carros clássicos. Eles estão sempre em busca de novos compradores e oportunidades para promover seu estoque.</td>
  </tr>
  <tr>
    <th>Necessidades</th>
    <td>
      Encontrar eventos de carros clássicos onde possam exibir seus veículos para um público interessado e potencialmente fechar negócios.   
    </td>
  </tr>
</table>

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Colecionador apaixonado.   | Quero encontrar eventos de carros clássicos que apresentem veículos raros e exclusivos.            | Para que eu possa expandir minha coleção e interagir com outros entusiastas, compartilhando minha paixão pela história automotiva.                |
|Visitante casual.      | Quero descobrir exposições e encontros de carros clássicos próximos à minha localização.                  | Para que eu possa desfrutar de uma experiência memorável, admirando belos exemplares de veículos históricos e absorvendo a atmosfera única desses eventos.  |
|Organizador de eventos.       | Quero listar meu evento de carros clássicos em uma plataforma confiável e de fácil acesso.                  | Para receber visitas no evento, garantindo o sucesso e promovendo a paixão pelos carros clássicos |
|Revendedor de carros clássicos.        | Quero encontrar eventos de carros clássicos bem frequentados, onde posso exibir meu estoque de veículos à venda.                  | Para atrair potenciais compradores e colecionadores, expandindo minha rede de contatos e fechando negócios lucrativos.  |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01| O usuário poderá se cadastrar no sistema.  | ALTA | 
|RF-02| O usuário poderá fazer a autenticação (login).    | ALTA |
|RF-03| O usuário poderá editar seu perfil.    | ALTA |
|RF-04| O usuário poderá deletar seu perfil.    | ALTA |
|RF-05| O usuário poderá visualizar todos os eventos disponíveis ativos.    | ALTA |
|RF-06| O usuário poderá buscar por eventos de forma segmentada.    | ALTA |
|RF-07| O usuário cadastrado no sistema poderá criar, editar e excluir eventos.    | ALTA |
|RF-08| Os usuários poderão dar “like” nos eventos.    | ALTO |
|RF-09| O usuário poderá gerar um relatório com todos os eventos que já foram publicados por ele.   | ALTA |
|RF-10| Possuir um mecanismo de chat.  | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-01| Design responsivo. | ALTA | 
|RNF-02| A plataforma deve ser compatível com uma variedade de navegadores modernos, como Chrome, Firefox, Safari e Edge, para garantir que a experiência do usuário seja consistente em diferentes ambientes |  ALTA | 
|RNF-03| A interface da plataforma deve ser intuitiva, de fácil uso, para acomodar tanto usuários experientes quanto aqueles menos familiarizados com tecnologia. |  ALTA |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| O framework ou biblioteca utilizado deverá ser apenas o BootStrap |
|03| Deverá ser utilizado html, css e javascript         |
|04| Não poder ser utilizado uma linguagem de programação diferente de C# no desenvolvimento do back-end        |

## Diagrama de Casos de Uso

<img width="600" alt="image" src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-roda-velha/assets/59897366/5a681c60-410b-4fa2-8577-9a217d7a8ea9">

