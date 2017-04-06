//
//  _MDPPlayerStatisticValueModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlayerStatisticValueModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlayerStatisticValueModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *value;
} MDPPlayerStatisticValueModelAttributes;

extern const struct MDPPlayerStatisticValueModelRelationships {
	__unsafe_unretained NSString *playerStatisticStatistic;
} MDPPlayerStatisticValueModelRelationships;

@class MDPPlayerStatisticModel;

@interface _MDPPlayerStatisticValueModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* name;

@property (atomic) uint16_t nameValue;
- (uint16_t)nameValue;
- (void)setNameValue:(uint16_t)value_;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* value;

//- (BOOL)validateValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPlayerStatisticModel *playerStatisticStatistic;

//- (BOOL)validatePlayerStatisticStatistic:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPlayerStatisticValueModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveName;
- (void)setPrimitiveName:(NSNumber*)value;

- (uint16_t)primitiveNameValue;
- (void)setPrimitiveNameValue:(uint16_t)value_;

- (NSDecimalNumber*)primitiveValue;
- (void)setPrimitiveValue:(NSDecimalNumber*)value;

- (MDPPlayerStatisticModel*)primitivePlayerStatisticStatistic;
- (void)setPrimitivePlayerStatisticStatistic:(MDPPlayerStatisticModel*)value;

@end
