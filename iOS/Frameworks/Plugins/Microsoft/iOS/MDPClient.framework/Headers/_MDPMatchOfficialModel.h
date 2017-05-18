//
//  _MDPMatchOfficialModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMatchOfficialModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMatchOfficialModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *officialId;
	__unsafe_unretained NSString *officialName;
	__unsafe_unretained NSString *officialType;
} MDPMatchOfficialModelAttributes;

extern const struct MDPMatchOfficialModelRelationships {
	__unsafe_unretained NSString *basketLiveMatchMatchOfficials;
	__unsafe_unretained NSString *footBallLiveMatchMatchOfficials;
} MDPMatchOfficialModelRelationships;

@class MDPBasketLiveMatchModel;
@class MDPFootballLiveMatchModel;

@interface _MDPMatchOfficialModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* officialId;

//- (BOOL)validateOfficialId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* officialName;

//- (BOOL)validateOfficialName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* officialType;

@property (atomic) uint16_t officialTypeValue;
- (uint16_t)officialTypeValue;
- (void)setOfficialTypeValue:(uint16_t)value_;

//- (BOOL)validateOfficialType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketLiveMatchModel *basketLiveMatchMatchOfficials;

//- (BOOL)validateBasketLiveMatchMatchOfficials:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchModel *footBallLiveMatchMatchOfficials;

//- (BOOL)validateFootBallLiveMatchMatchOfficials:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMatchOfficialModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveOfficialId;
- (void)setPrimitiveOfficialId:(NSString*)value;

- (NSString*)primitiveOfficialName;
- (void)setPrimitiveOfficialName:(NSString*)value;

- (NSNumber*)primitiveOfficialType;
- (void)setPrimitiveOfficialType:(NSNumber*)value;

- (uint16_t)primitiveOfficialTypeValue;
- (void)setPrimitiveOfficialTypeValue:(uint16_t)value_;

- (MDPBasketLiveMatchModel*)primitiveBasketLiveMatchMatchOfficials;
- (void)setPrimitiveBasketLiveMatchMatchOfficials:(MDPBasketLiveMatchModel*)value;

- (MDPFootballLiveMatchModel*)primitiveFootBallLiveMatchMatchOfficials;
- (void)setPrimitiveFootBallLiveMatchMatchOfficials:(MDPFootballLiveMatchModel*)value;

@end
