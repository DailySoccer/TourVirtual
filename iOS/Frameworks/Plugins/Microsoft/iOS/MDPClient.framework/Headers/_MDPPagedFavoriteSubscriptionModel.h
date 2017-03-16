//
//  _MDPPagedFavoriteSubscriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedFavoriteSubscriptionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedFavoriteSubscriptionModelAttributes {
	__unsafe_unretained NSString *continuationToken;
	__unsafe_unretained NSString *continuationTokenB64;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPPagedFavoriteSubscriptionModelAttributes;

extern const struct MDPPagedFavoriteSubscriptionModelRelationships {
	__unsafe_unretained NSString *pagedFavoriteSubscriptionRequest;
	__unsafe_unretained NSString *results;
} MDPPagedFavoriteSubscriptionModelRelationships;

@class MDPPagedFavoriteSubscriptionRequestModel;
@class MDPFavoriteSubscriptionModel;

@interface _MDPPagedFavoriteSubscriptionModel : NSManagedObject

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

@property (nonatomic, strong) MDPPagedFavoriteSubscriptionRequestModel *pagedFavoriteSubscriptionRequest;

//- (BOOL)validatePagedFavoriteSubscriptionRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *results;

- (NSMutableOrderedSet*)resultsSet;

@end

@interface _MDPPagedFavoriteSubscriptionModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSOrderedSet*)value_;
- (void)removeResults:(NSOrderedSet*)value_;
- (void)addResultsObject:(MDPFavoriteSubscriptionModel*)value_;
- (void)removeResultsObject:(MDPFavoriteSubscriptionModel*)value_;
@end

@interface _MDPPagedFavoriteSubscriptionModel (CoreDataGeneratedPrimitiveAccessors)

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

- (MDPPagedFavoriteSubscriptionRequestModel*)primitivePagedFavoriteSubscriptionRequest;
- (void)setPrimitivePagedFavoriteSubscriptionRequest:(MDPPagedFavoriteSubscriptionRequestModel*)value;

- (NSMutableOrderedSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableOrderedSet*)value;

@end
