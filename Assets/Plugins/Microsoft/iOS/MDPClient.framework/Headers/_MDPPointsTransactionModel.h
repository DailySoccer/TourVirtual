//
//  _MDPPointsTransactionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPointsTransactionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPointsTransactionModelAttributes {
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *idAction;
	__unsafe_unretained NSString *idPointsOperation;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *numPoints;
	__unsafe_unretained NSString *runningTotal;
} MDPPointsTransactionModelAttributes;

extern const struct MDPPointsTransactionModelRelationships {
	__unsafe_unretained NSString *actionDescription;
	__unsafe_unretained NSString *pagedPointsTransactionsResults;
} MDPPointsTransactionModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPPagedPointsTransactionsModel;

@interface _MDPPointsTransactionModel : NSManagedObject

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAction;

//- (BOOL)validateIdAction:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPointsOperation;

//- (BOOL)validateIdPointsOperation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* numPoints;

@property (atomic) int64_t numPointsValue;
- (int64_t)numPointsValue;
- (void)setNumPointsValue:(int64_t)value_;

//- (BOOL)validateNumPoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* runningTotal;

//- (BOOL)validateRunningTotal:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *actionDescription;

- (NSMutableSet*)actionDescriptionSet;

@property (nonatomic, strong) MDPPagedPointsTransactionsModel *pagedPointsTransactionsResults;

//- (BOOL)validatePagedPointsTransactionsResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPointsTransactionModel (ActionDescriptionCoreDataGeneratedAccessors)
- (void)addActionDescription:(NSSet*)value_;
- (void)removeActionDescription:(NSSet*)value_;
- (void)addActionDescriptionObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeActionDescriptionObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPPointsTransactionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSString*)primitiveIdAction;
- (void)setPrimitiveIdAction:(NSString*)value;

- (NSString*)primitiveIdPointsOperation;
- (void)setPrimitiveIdPointsOperation:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveNumPoints;
- (void)setPrimitiveNumPoints:(NSNumber*)value;

- (int64_t)primitiveNumPointsValue;
- (void)setPrimitiveNumPointsValue:(int64_t)value_;

- (NSString*)primitiveRunningTotal;
- (void)setPrimitiveRunningTotal:(NSString*)value;

- (NSMutableSet*)primitiveActionDescription;
- (void)setPrimitiveActionDescription:(NSMutableSet*)value;

- (MDPPagedPointsTransactionsModel*)primitivePagedPointsTransactionsResults;
- (void)setPrimitivePagedPointsTransactionsResults:(MDPPagedPointsTransactionsModel*)value;

@end
