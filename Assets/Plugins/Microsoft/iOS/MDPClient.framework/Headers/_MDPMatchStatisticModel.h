//
//  _MDPMatchStatisticModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMatchStatisticModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMatchStatisticModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *value;
} MDPMatchStatisticModelAttributes;

extern const struct MDPMatchStatisticModelRelationships {
	__unsafe_unretained NSString *matchPremiumStatistics;
	__unsafe_unretained NSString *matchStatistics;
} MDPMatchStatisticModelRelationships;

@class MDPMatchModel;
@class MDPMatchModel;

@interface _MDPMatchStatisticModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* value;

//- (BOOL)validateValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchModel *matchPremiumStatistics;

//- (BOOL)validateMatchPremiumStatistics:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchModel *matchStatistics;

//- (BOOL)validateMatchStatistics:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMatchStatisticModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSDecimalNumber*)primitiveValue;
- (void)setPrimitiveValue:(NSDecimalNumber*)value;

- (MDPMatchModel*)primitiveMatchPremiumStatistics;
- (void)setPrimitiveMatchPremiumStatistics:(MDPMatchModel*)value;

- (MDPMatchModel*)primitiveMatchStatistics;
- (void)setPrimitiveMatchStatistics:(MDPMatchModel*)value;

@end
