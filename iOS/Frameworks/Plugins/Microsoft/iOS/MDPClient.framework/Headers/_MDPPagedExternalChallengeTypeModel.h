//
//  _MDPPagedExternalChallengeTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedExternalChallengeTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedExternalChallengeTypeModelAttributes {
	__unsafe_unretained NSString *currentPage;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *pageCount;
	__unsafe_unretained NSString *pageSize;
	__unsafe_unretained NSString *totalItems;
} MDPPagedExternalChallengeTypeModelAttributes;

extern const struct MDPPagedExternalChallengeTypeModelRelationships {
	__unsafe_unretained NSString *pagedExternalChallengeTypeRequest;
	__unsafe_unretained NSString *results;
} MDPPagedExternalChallengeTypeModelRelationships;

@class MDPPagedExternalChallengeTypeRequestModel;
@class MDPExternalChallengeTypeModel;

@interface _MDPPagedExternalChallengeTypeModel : NSManagedObject

@property (nonatomic, strong) NSNumber* currentPage;

@property (atomic) int64_t currentPageValue;
- (int64_t)currentPageValue;
- (void)setCurrentPageValue:(int64_t)value_;

//- (BOOL)validateCurrentPage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasMoreResults;

@property (atomic) BOOL hasMoreResultsValue;
- (BOOL)hasMoreResultsValue;
- (void)setHasMoreResultsValue:(BOOL)value_;

//- (BOOL)validateHasMoreResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageCount;

@property (atomic) int64_t pageCountValue;
- (int64_t)pageCountValue;
- (void)setPageCountValue:(int64_t)value_;

//- (BOOL)validatePageCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageSize;

@property (atomic) int64_t pageSizeValue;
- (int64_t)pageSizeValue;
- (void)setPageSizeValue:(int64_t)value_;

//- (BOOL)validatePageSize:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalItems;

@property (atomic) int64_t totalItemsValue;
- (int64_t)totalItemsValue;
- (void)setTotalItemsValue:(int64_t)value_;

//- (BOOL)validateTotalItems:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedExternalChallengeTypeRequestModel *pagedExternalChallengeTypeRequest;

//- (BOOL)validatePagedExternalChallengeTypeRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *results;

- (NSMutableSet*)resultsSet;

@end

@interface _MDPPagedExternalChallengeTypeModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSSet*)value_;
- (void)removeResults:(NSSet*)value_;
- (void)addResultsObject:(MDPExternalChallengeTypeModel*)value_;
- (void)removeResultsObject:(MDPExternalChallengeTypeModel*)value_;
@end

@interface _MDPPagedExternalChallengeTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCurrentPage;
- (void)setPrimitiveCurrentPage:(NSNumber*)value;

- (int64_t)primitiveCurrentPageValue;
- (void)setPrimitiveCurrentPageValue:(int64_t)value_;

- (NSNumber*)primitiveHasMoreResults;
- (void)setPrimitiveHasMoreResults:(NSNumber*)value;

- (BOOL)primitiveHasMoreResultsValue;
- (void)setPrimitiveHasMoreResultsValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePageCount;
- (void)setPrimitivePageCount:(NSNumber*)value;

- (int64_t)primitivePageCountValue;
- (void)setPrimitivePageCountValue:(int64_t)value_;

- (NSNumber*)primitivePageSize;
- (void)setPrimitivePageSize:(NSNumber*)value;

- (int64_t)primitivePageSizeValue;
- (void)setPrimitivePageSizeValue:(int64_t)value_;

- (NSNumber*)primitiveTotalItems;
- (void)setPrimitiveTotalItems:(NSNumber*)value;

- (int64_t)primitiveTotalItemsValue;
- (void)setPrimitiveTotalItemsValue:(int64_t)value_;

- (MDPPagedExternalChallengeTypeRequestModel*)primitivePagedExternalChallengeTypeRequest;
- (void)setPrimitivePagedExternalChallengeTypeRequest:(MDPPagedExternalChallengeTypeRequestModel*)value;

- (NSMutableSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableSet*)value;

@end
