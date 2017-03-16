//
//  _MDPPagedFanVirtualGoodsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedFanVirtualGoodsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedFanVirtualGoodsModelAttributes {
	__unsafe_unretained NSString *continuationToken;
	__unsafe_unretained NSString *continuationTokenB64;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPPagedFanVirtualGoodsModelAttributes;

extern const struct MDPPagedFanVirtualGoodsModelRelationships {
	__unsafe_unretained NSString *pagedFanVirtualGoodsRequest;
	__unsafe_unretained NSString *results;
} MDPPagedFanVirtualGoodsModelRelationships;

@class MDPPagedFanVirtualGoodsRequestModel;
@class MDPFanVirtualGoodModel;

@interface _MDPPagedFanVirtualGoodsModel : NSManagedObject

@property (nonatomic, strong) NSString* continuationToken;

//- (BOOL)validateContinuationToken:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* continuationTokenB64;

//- (BOOL)validateContinuationTokenB64:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasMoreResults;

@property (atomic) BOOL hasMoreResultsValue;
- (BOOL)hasMoreResultsValue;
- (void)setHasMoreResultsValue:(BOOL)value_;

//- (BOOL)validateHasMoreResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedFanVirtualGoodsRequestModel *pagedFanVirtualGoodsRequest;

//- (BOOL)validatePagedFanVirtualGoodsRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *results;

- (NSMutableSet*)resultsSet;

@end

@interface _MDPPagedFanVirtualGoodsModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSSet*)value_;
- (void)removeResults:(NSSet*)value_;
- (void)addResultsObject:(MDPFanVirtualGoodModel*)value_;
- (void)removeResultsObject:(MDPFanVirtualGoodModel*)value_;
@end

@interface _MDPPagedFanVirtualGoodsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveContinuationToken;
- (void)setPrimitiveContinuationToken:(NSString*)value;

- (NSString*)primitiveContinuationTokenB64;
- (void)setPrimitiveContinuationTokenB64:(NSString*)value;

- (NSNumber*)primitiveHasMoreResults;
- (void)setPrimitiveHasMoreResults:(NSNumber*)value;

- (BOOL)primitiveHasMoreResultsValue;
- (void)setPrimitiveHasMoreResultsValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPPagedFanVirtualGoodsRequestModel*)primitivePagedFanVirtualGoodsRequest;
- (void)setPrimitivePagedFanVirtualGoodsRequest:(MDPPagedFanVirtualGoodsRequestModel*)value;

- (NSMutableSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableSet*)value;

@end
